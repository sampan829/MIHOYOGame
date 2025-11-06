// 创建脚本 MouseLook.cs
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("鼠标灵敏度")]
    public float mouseSensitivity = 100f;

    [Header("视角限制")]
    public float minVerticalAngle = -90f;
    public float maxVerticalAngle = 90f;

    private Transform playerBody;
    private float xRotation = 0f;

    void Start()
    {
        playerBody = transform.parent;

        // 锁定鼠标到屏幕中心
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMouseLook();

        // 按ESC键切换鼠标锁定状态
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameRoot.Instance.UIManagerRoot.uidic.ContainsKey(trueExitPanel.uIType.Name) || gameRoot.Instance.UIManagerRoot.uidic.ContainsKey(EscPanel.uIType.Name)
                    || gameRoot.Instance.UIManagerRoot.uidic.ContainsKey(settingPanel.uIType.Name)) return;
               
            ToggleCursorLock();
        }
    }

    private void HandleMouseLook()
    {
        // 获取鼠标输入
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // 垂直视角旋转（摄像机上下看）
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minVerticalAngle, maxVerticalAngle);

        // 应用垂直旋转到摄像机
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // 水平视角旋转（玩家身体左右转）
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ToggleCursorLock()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}