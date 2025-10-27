using System.Collections;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    [Header("材质设置")]
    public Material originMaterial;    // 原始材质
    public Material highlightMaterial; // 高亮材质

    [Header("时间设置")]
    public float fadeInTime = 0.5f;    // 渐亮时间
    public float stayTime = 1.0f;      // 高亮保持时间
    public float fadeOutTime = 0.5f;   // 渐灭时间

    private Renderer floorRenderer;
    private bool isHighlighting = false;
    private Material highlightMaterialInstance; // 使用材质实例而非原始材质

    void Start()
    {
        floorRenderer = GetComponent<Renderer>();
        floorRenderer.material = originMaterial;

        // 创建高亮材质的实例，避免修改原始材质
        highlightMaterialInstance = new Material(highlightMaterial);

        // 确保初始状态正确
        SetEmissionIntensity(0f);
    }

    // 鼠标点击时调用的方法
    public void OnFloorClicked()
    {
        if (!isHighlighting)
        {
            StartCoroutine(HighlightSequence());
        }
    }

    private IEnumerator HighlightSequence()
    {
        isHighlighting = true;

        // 切换到高亮材质实例
        floorRenderer.material = highlightMaterialInstance;

        // 确保材质启用Emission
        highlightMaterialInstance.EnableKeyword("_EMISSION");

        // 渐亮阶段 (0.5秒)
        float timer = 0f;
        while (timer < fadeInTime)
        {
            timer += Time.deltaTime;
            float intensity = Mathf.Lerp(0f, 1f, timer / fadeInTime);
            SetEmissionIntensity(intensity);
            yield return null;
        }

        // 保持最高亮度
        SetEmissionIntensity(1f);

        // 保持高亮阶段 (1秒)
        yield return new WaitForSeconds(stayTime);

        // 渐灭阶段 (0.5秒)
        timer = 0f;
        while (timer < fadeOutTime)
        {
            timer += Time.deltaTime;
            float intensity = Mathf.Lerp(1f, 0f, timer / fadeOutTime);
            SetEmissionIntensity(intensity);
            yield return null;
        }

        // 确保完全熄灭
        SetEmissionIntensity(0f);

        // 切换回原始材质
        floorRenderer.material = originMaterial;
        isHighlighting = false;
    }

    private void SetEmissionIntensity(float intensity)
    {
        if (highlightMaterialInstance != null)
        {
            // 获取原始发射颜色并调整强度
            Color baseEmissionColor = highlightMaterial.GetColor("_EmissionColor");
            Color currentColor = baseEmissionColor * intensity;

            // 设置发射颜色
            highlightMaterialInstance.SetColor("_EmissionColor", currentColor);

            // 强制更新全局光照
            RendererExtensions.UpdateGIMaterials(floorRenderer);

            // 如果需要，也可以更新动态GI
            // DynamicGI.SetEmissive(floorRenderer, currentColor);
        }
    }

    void OnDestroy()
    {
        // 清理材质实例
        if (highlightMaterialInstance != null)
        {
            DestroyImmediate(highlightMaterialInstance);
        }
    }
}