using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactDistance;
    public LayerMask interactableLayer;

    private Camera mainCamera;
    private IInteractable currentInteractable;
    private GameObject currentInteractableObject;
    private Outline outlineEffect;
    private PlayerInputActions inputActions;

    void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.Player.Interact.performed += ctx => HandleInteraction();
        DontDestroyOnLoad(this);
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
        InteractPromptPanel.Instance.Hide();
    }

    void Update()
    {
        CheckForInteractable();
    }

    void CheckForInteractable()
    {
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactableLayer))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != currentInteractable)
            {
                if(outlineEffect != null)
                    outlineEffect.enabled = false;
                
                currentInteractable = interactable;
                currentInteractableObject = hit.collider.gameObject;
                outlineEffect = currentInteractableObject.GetComponent<Outline>();
                
                if (currentInteractable != null)
                {
                    if (outlineEffect != null)
                        outlineEffect.enabled = true;
                    InteractPromptPanel.Instance.Show(currentInteractable.InteractPrompt);
                }
                else
                    InteractPromptPanel.Instance.Hide();
                    
            }

        }
        else
        {
            if (currentInteractable != null && outlineEffect != null)
                outlineEffect.enabled = false;
            
            currentInteractable = null;
            currentInteractableObject = null;
            InteractPromptPanel.Instance.Hide();
        }
    }

    void HandleInteraction()
    {
        currentInteractable?.Interact();
    }

}
