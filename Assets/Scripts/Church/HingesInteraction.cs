using UnityEngine;

public class HingesInteraction : MonoBehaviour, IInteractable
{
    public string InteractPrompt => "E Open";
    [SerializeField] private Animator animatior;
    [SerializeField] private AnimationClip doorOpenAnim;
    [SerializeField] private AnimationClip doorCloseAnim;
    private bool isOpen;

    void Awake()
    {
        isOpen = false;
    }

    public void Interact()
    {
        if (isOpen)
        {
            isOpen = false;
            animatior.Play(doorCloseAnim.name, 0);
        }
        else
        {
            isOpen = true;
            animatior.Play(doorOpenAnim.name, 0);
        }
    }
}
