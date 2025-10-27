using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class MeshSplitter : EditorWindow
{
    public GameObject targetObject;
    public Vector3Int gridDivision = new Vector3Int(2, 2, 2);

    [MenuItem("Tools/Mesh Splitter")]
    public static void ShowWindow()
    {
        GetWindow<MeshSplitter>("Mesh Splitter");
    }

    void OnGUI()
    {
        GUILayout.Label("Mesh Splitting Tool", EditorStyles.boldLabel);

        targetObject = (GameObject)EditorGUILayout.ObjectField("Target Object", targetObject, typeof(GameObject), true);
        gridDivision = EditorGUILayout.Vector3IntField("Grid Division", gridDivision);

        if (GUILayout.Button("Split Mesh") && targetObject != null)
        {
            SplitMeshInEditor();
        }
    }

    void SplitMeshInEditor()
    {
        MeshFilter meshFilter = targetObject.GetComponent<MeshFilter>();
        if (meshFilter == null || meshFilter.sharedMesh == null)
        {
            Debug.LogError("No mesh found on target object");
            return;
        }

        Mesh originalMesh = meshFilter.sharedMesh;
        Material material = targetObject.GetComponent<MeshRenderer>()?.sharedMaterial;

        // 创建父对象来组织所有碎片
        GameObject parentObject = new GameObject($"{targetObject.name}_Fragments");
        parentObject.transform.position = targetObject.transform.position;

        // 获取原始网格的包围盒
        Bounds bounds = originalMesh.bounds;
        Vector3 chunkSize = new Vector3(
            bounds.size.x / gridDivision.x,
            bounds.size.y / gridDivision.y,
            bounds.size.z / gridDivision.z
        );

        // 为每个网格单元创建碎片
        for (int x = 0; x < gridDivision.x; x++)
        {
            for (int y = 0; y < gridDivision.y; y++)
            {
                for (int z = 0; z < gridDivision.z; z++)
                {
                    CreateMeshChunk(originalMesh, bounds, chunkSize, new Vector3Int(x, y, z),
                                  parentObject.transform, material);
                }
            }
        }

        // 可选：禁用原始对象
        targetObject.SetActive(false);

        Debug.Log($"Successfully created {gridDivision.x * gridDivision.y * gridDivision.z} mesh fragments");
    }

    void CreateMeshChunk(Mesh originalMesh, Bounds bounds, Vector3 chunkSize, Vector3Int index,
                        Transform parent, Material material)
    {
        // 计算当前碎片的包围盒
        Vector3 min = bounds.min + Vector3.Scale(chunkSize, new Vector3(index.x, index.y, index.z));
        Vector3 max = min + chunkSize;

        // 提取在当前包围盒内的三角形
        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        List<Vector2> uvs = new List<Vector2>();
        List<Vector3> normals = new List<Vector3>();

        Vector3[] originalVertices = originalMesh.vertices;
        int[] originalTriangles = originalMesh.triangles;
        Vector2[] originalUVs = originalMesh.uv;
        Vector3[] originalNormals = originalMesh.normals;

        Dictionary<int, int> vertexMapping = new Dictionary<int, int>();

        // 遍历所有三角形，只保留在当前碎片包围盒内的部分
        for (int i = 0; i < originalTriangles.Length; i += 3)
        {
            int i1 = originalTriangles[i];
            int i2 = originalTriangles[i + 1];
            int i3 = originalTriangles[i + 2];

            Vector3 v1 = originalVertices[i1];
            Vector3 v2 = originalVertices[i2];
            Vector3 v3 = originalVertices[i3];

            // 检查三角形中心是否在当前碎片内
            Vector3 center = (v1 + v2 + v3) / 3f;
            if (IsPointInBounds(center, min, max))
            {
                AddTriangle(i1, i2, i3, originalVertices, originalUVs, originalNormals,
                           vertices, triangles, uvs, normals, vertexMapping);
            }
        }

        if (vertices.Count > 0)
        {
            // 创建新的网格
            Mesh chunkMesh = new Mesh();
            chunkMesh.vertices = vertices.ToArray();
            chunkMesh.triangles = triangles.ToArray();
            chunkMesh.uv = uvs.ToArray();
            chunkMesh.normals = normals.ToArray();
            chunkMesh.RecalculateBounds();

            // 创建GameObject
            GameObject chunk = new GameObject($"Chunk_{index.x}_{index.y}_{index.z}");
            chunk.transform.SetParent(parent);
            chunk.transform.localPosition = Vector3.zero;

            MeshFilter mf = chunk.AddComponent<MeshFilter>();
            mf.mesh = chunkMesh;

            MeshRenderer mr = chunk.AddComponent<MeshRenderer>();
            if (material != null) mr.material = material;

            // 添加物理组件
            MeshCollider collider = chunk.AddComponent<MeshCollider>();
            collider.convex = true;
            chunk.AddComponent<Rigidbody>();
        }
    }

    bool IsPointInBounds(Vector3 point, Vector3 min, Vector3 max)
    {
        return point.x >= min.x && point.x <= max.x &&
               point.y >= min.y && point.y <= max.y &&
               point.z >= min.z && point.z <= max.z;
    }

    void AddTriangle(int i1, int i2, int i3, Vector3[] originalVertices, Vector2[] originalUVs,
                    Vector3[] originalNormals, List<Vector3> vertices, List<int> triangles,
                    List<Vector2> uvs, List<Vector3> normals, Dictionary<int, int> vertexMapping)
    {
        int GetNewIndex(int originalIndex)
        {
            if (!vertexMapping.TryGetValue(originalIndex, out int newIndex))
            {
                newIndex = vertices.Count;
                vertices.Add(originalVertices[originalIndex]);
                uvs.Add(originalUVs.Length > originalIndex ? originalUVs[originalIndex] : Vector2.zero);
                normals.Add(originalNormals.Length > originalIndex ? originalNormals[originalIndex] : Vector3.up);
                vertexMapping[originalIndex] = newIndex;
            }
            return newIndex;
        }

        triangles.Add(GetNewIndex(i1));
        triangles.Add(GetNewIndex(i2));
        triangles.Add(GetNewIndex(i3));
    }
}