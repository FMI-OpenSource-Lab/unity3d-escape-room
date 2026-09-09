using UnityEngine;

public class LibraryDoorInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator animDoor;
    [SerializeField] private AnimationClip openDoor, closeDoor;
    private bool isOpen;
    public string InteractPrompt
    {
        get
        {
            if (LockPanelInteraction.Instance.isUnlocked)
                return "E";
            return "";
        }
    }

    public void Awake()
    {
        isOpen = false;
    }
    public void Interact()
    {
        if (LockPanelInteraction.Instance.isUnlocked)
        {
            if (isOpen)
            {
                isOpen = false;
                animDoor.Play(closeDoor.name);
            }
            else
            {
                isOpen = true;
                animDoor.Play(openDoor.name);
            }
        }
    }
}
