// 更新 CrosshairController.cs
using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    [Header("准星设置")]
    public Texture2D crosshairTexture;
    public Vector2 crosshairSize = new Vector2(20, 20);

    [Header("射线检测")]
    public float interactionDistance = 100f;
    public LayerMask floorLayerMask = -1;

    void Update()
    {
        CheckForFloorClick();
    }

    void OnGUI()
    {
        // 只在鼠标锁定时显示准星
        if (Cursor.lockState == CursorLockMode.Locked && crosshairTexture != null)
        {
            Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
            Rect crosshairRect = new Rect(
                screenCenter.x - crosshairSize.x / 2,
                screenCenter.y - crosshairSize.y / 2,
                crosshairSize.x,
                crosshairSize.y
            );
            GUI.DrawTexture(crosshairRect, crosshairTexture);
        }
    }

    private void CheckForFloorClick()
    {
        if (Input.GetMouseButtonDown(0) && Cursor.lockState == CursorLockMode.Locked)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionDistance, floorLayerMask))
            {
                FloorController floor = hit.collider.GetComponent<FloorController>();
                if (floor != null)
                {
                    floor.OnFloorClicked();
                }
            }
        }
    }
}