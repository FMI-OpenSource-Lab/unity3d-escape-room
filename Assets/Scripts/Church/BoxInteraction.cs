using UnityEngine;

public class BoxInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator anim;
    [SerializeField] private AnimationClip pullOut, openLid;
    private bool isPulled;
    public string InteractPrompt
    {
        get
        {
            if (BoxPanelInteraction.Instance.isUnlocked)
                return "E Open";
            else
                return "E";
        }
    }

    public void Awake()
    {
        isPulled = false;
    }

    public void Interact()
    {
        if(isPulled && BoxPanelInteraction.Instance.isUnlocked)
        {
            anim.Play(openLid.name);
        }
        if (!isPulled)
        {
            anim.Play(pullOut.name);
            isPulled = true;
        }
        else
            BoxPanelInteraction.Instance.Show();
    }
}
