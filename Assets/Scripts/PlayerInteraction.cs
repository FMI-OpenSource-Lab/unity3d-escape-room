using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public float interactDistance = 20f;
    public LayerMask interactableLayer;
    public GameObject interactPromptUI;
    public TextMeshProUGUI interactPromptText;
    public GameObject passwordPanel;
    public TMP_InputField passwordInputField;
    public TextMeshProUGUI hintText;
    public PlayerActionsManager2 playerActionsManager; // Reference to PlayerActionsManager

    private Camera mainCamera;
    private GameObject currentInteractable;
    private Outline outlineEffect;
    private PlayerInputActions inputActions;

    void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.Player.Interact.performed += ctx => HandleInteraction();
    }

    void OnEnable()
    {
        inputActions.Player.Enable();
    }

    void OnDisable()
    {
        inputActions.Player.Disable();
    }

    void Start()
    {
        mainCamera = Camera.main;
        interactPromptUI.SetActive(false);
        passwordPanel.SetActive(false); // Ensure the panel is hidden initially
    }

    void Update()
    {
        if (!passwordPanel.activeSelf) // Only check for interactables if the password panel is not active
        {
            CheckForInteractable();
        }
    }

    void CheckForInteractable()
    {
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactableLayer))
        {
            GameObject hitObject = hit.collider.gameObject;
            Debug.Log("Raycast hit: " + hitObject.name); // Log the name of the hit object

            if (hitObject != currentInteractable)
            {
                if (currentInteractable != null && outlineEffect != null)
                {
                    outlineEffect.enabled = false;
                }

                currentInteractable = hitObject;
                outlineEffect = currentInteractable.GetComponent<Outline>();
                if (outlineEffect != null)
                {
                    outlineEffect.enabled = true;
                    ShowInteractPrompt("Open");
                }
            }
        }
        else
        {
            if (currentInteractable != null && outlineEffect != null)
            {
                outlineEffect.enabled = false;
            }
            currentInteractable = null;
            HideInteractPrompt();
        }
    }

    void HandleInteraction()
    {
        Debug.Log("HandleInteraction called"); // Debug log to confirm interaction handling
        if (currentInteractable != null)
        {
            Debug.Log("Current interactable: " + currentInteractable.name); // Log the name of the current interactable
            if (currentInteractable.CompareTag("Safe"))
            {
                ShowPasswordPanel("Hmm.. seems like someone is trying to open the safe. If you are that curious why don't you go eat some cookies or drink some coffee or maybe even read a book. You might find something interesting there.");
            }
        }
        else
        {
            Debug.LogError("No current interactable set");
        }
    }

    void ShowInteractPrompt(string message)
    {
        interactPromptText.text = message;
        interactPromptUI.SetActive(true);
    }

    void HideInteractPrompt()
    {
        interactPromptUI.SetActive(false);
    }

    void ShowPasswordPanel(string hint)
    {
        hintText.text = hint;
        passwordPanel.SetActive(true);
        passwordInputField.ActivateInputField(); // Focus the input field
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        playerActionsManager.SetCanLook(false); // Disable camera movement
    }

    public void SubmitPassword()
    {
        Debug.Log("SubmitPassword called"); // Debug log to verify method call
        if (currentInteractable == null)
        {
            Debug.LogError("No current interactable set");
            return;
        }

        string enteredPassword = passwordInputField.text;
        SafeInteract safeInteract = currentInteractable.GetComponent<SafeInteract>();
        if (safeInteract != null)
        {
            Debug.Log("SafeInteract component found"); // Debug log to verify component
            safeInteract.TryOpenSafe(enteredPassword);
        }
        else
        {
            Debug.LogError("No SafeInteract component found on currentInteractable");
        }
        ClosePasswordPanel();
    }

    public void ClosePasswordPanel()
    {
        passwordPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerActionsManager.SetCanLook(true); // Re-enable camera movement
    }
}
