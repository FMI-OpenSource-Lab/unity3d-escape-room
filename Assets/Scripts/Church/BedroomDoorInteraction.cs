using UnityEngine;

public class BedroomDoorInteraction : MonoBehaviour, IInteractable
{
    public string InteractPrompt => "E";
    [SerializeField] private Animator anim;
    [SerializeField] private AnimationClip openAnim, closeAnim;
    private bool isOpen;

    public void Awake()
    {
        isOpen = true;
    }

    public void Interact()
    {
        if (isOpen)
        {
            anim.Play(closeAnim.name);
            isOpen = false;
        } 
        else
        {
            anim.Play(openAnim.name);
            isOpen = true;
        }
            
    }
}
