using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActionsManager2 : MonoBehaviour
{
    public static PlayerActionsManager2 Instance { get; private set; }

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float gravityScale = 5f;
    public float lookSensitivity = 0.5f;
    public Transform groundCheck; // Ground check object
    public LayerMask groundLayer; // Ground layer
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private AnimationClip playerCrouch;
    [SerializeField] private AnimationClip playerGetUp;


    private PlayerInputActions playerInputActions;
    private Rigidbody rb;
    private GameObject flashlight;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private bool jumpInput;
    private float verticalLookRotation;
    private bool canLook = true; // Control camera look
    private bool isOn;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        rb = GetComponent<Rigidbody>();
        playerInputActions = new PlayerInputActions();

        playerInputActions.Player.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerInputActions.Player.Movement.canceled += ctx => moveInput = Vector2.zero;

        playerInputActions.Player.Jump.performed += ctx => jumpInput = true;

        playerInputActions.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        playerInputActions.Player.Look.canceled += ctx => lookInput = Vector2.zero;

        flashlight = GameObject.FindWithTag("Flashlight");
        flashlight.SetActive(false);
        isOn = false;
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

            if (Keyboard.current.ctrlKey.wasPressedThisFrame)
            {
                playerAnimator.Play(playerCrouch.name);
            }

            if (Keyboard.current.ctrlKey.wasReleasedThisFrame)
            {
                playerAnimator.Play(playerGetUp.name);
            }

            if (Keyboard.current.shiftKey.wasPressedThisFrame)
            {
                moveSpeed *= 1.6f;
            }

            if (Keyboard.current.shiftKey.wasReleasedThisFrame)
            {
                moveSpeed /= 1.6f;
            }

            if (Keyboard.current.fKey.wasPressedThisFrame)
            {
                FlashlightToggle();
            } 
                
        }
    }

    private void FlashlightToggle()
    {
        isOn = !isOn;
        flashlight.SetActive(isOn);
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        Vector3 newVelocity = new Vector3(move.x * moveSpeed, rb.linearVelocity.y, move.z * moveSpeed);
        rb.linearVelocity = newVelocity;

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
