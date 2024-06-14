using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActionsManager2 : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float lookSensitivity = 0.1f;
    public Transform groundCheck; // Ground check object
    public LayerMask groundLayer; // Ground layer

    private PlayerInputActions playerInputActions;
    private Rigidbody rb;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private bool jumpInput;
    private float verticalLookRotation;
    private bool canLook = true; // Control camera look

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInputActions = new PlayerInputActions();

        playerInputActions.Player.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerInputActions.Player.Movement.canceled += ctx => moveInput = Vector2.zero;

        playerInputActions.Player.Jump.performed += ctx => jumpInput = true;

        playerInputActions.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        playerInputActions.Player.Look.canceled += ctx => lookInput = Vector2.zero;
    }

    private void OnEnable()
    {
        playerInputActions.Player.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Player.Disable();
    }

    private void Update()
    {
        if (canLook)
        {
            HandleLook();
        }
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        Vector3 newVelocity = new Vector3(move.x * moveSpeed, rb.velocity.y, move.z * moveSpeed);
        rb.velocity = newVelocity;

        if (jumpInput && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpInput = false;
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(groundCheck.position, Vector3.down, 0.2f, groundLayer);
    }

    private void HandleLook()
    {
        Vector2 look = lookInput * lookSensitivity;
        transform.Rotate(0, look.x, 0);

        verticalLookRotation -= look.y;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalLookRotation, 0, 0);
    }

    public void SetCanLook(bool value)
    {
        canLook = value;
    }
}
