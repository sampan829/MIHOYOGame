using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [Header("移动设置")]
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    public float jumpHeight = 1.5f;
    public float gravity = -9.81f;
    public float airControl = 0.5f; // 空中移动控制系数

    [Header("地面检测")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private CharacterController controller;
    private Camera playerCamera;
    private Vector3 velocity;
    private bool isGrounded;
    private float currentSpeed;

    // 跳跃状态跟踪
    private bool jumpRequested = false; // 跳跃请求标志
    private bool wasGrounded = true; // 上一帧是否在地面

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();

        // 如果没有设置地面检测点，自动创建
        if (groundCheck == null)
        {
            GameObject groundCheckObj = new GameObject("GroundCheck");
            groundCheckObj.transform.SetParent(transform);
            groundCheckObj.transform.localPosition = new Vector3(0, -controller.height / 2 - 0.1f, 0);
            groundCheck = groundCheckObj.transform;
        }

        currentSpeed = walkSpeed;
    }

    void Update()
    {
        CheckGrounded();
        HandleMovement();
        HandleJumpInput();
        ApplyGravity();
        ApplyJump();
    }

    private void CheckGrounded()
    {
        // 检测是否在地面
        bool previouslyGrounded = isGrounded;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // 如果在地面且Y速度向下，重置Y速度
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // 更新上一帧的地面状态
        wasGrounded = previouslyGrounded;
    }

    private void HandleMovement()
    {
        // 获取输入
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // 跑步切换
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }

        // 计算移动方向
        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;

        // 空中移动控制
        float moveControl = isGrounded ? 1f : airControl;

        // 应用移动
        controller.Move(moveDirection * currentSpeed * moveControl * Time.deltaTime);
    }

    private void HandleJumpInput()
    {
        // 检测跳跃输入
        if (Input.GetButtonDown("Jump"))
        {
            // 只有在地面时才能请求跳跃
            if (isGrounded)
            {
                jumpRequested = true;
            }
        }
    }

    private void ApplyJump()
    {
        // 如果有跳跃请求且在地面，执行跳跃
        if (jumpRequested && isGrounded)
        {
            // 计算跳跃速度
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            // 重置跳跃请求
            jumpRequested = false;

            Debug.Log("执行跳跃!");
        }
    }

    private void ApplyGravity()
    {
        // 应用重力
        velocity.y += gravity * Time.deltaTime;

        // 应用Y轴速度
        controller.Move(velocity * Time.deltaTime);
    }

    // 在编辑器中显示地面检测范围
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = isGrounded ? Color.green : Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
        }
    }
}