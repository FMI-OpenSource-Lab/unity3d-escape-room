using UnityEngine;

public class LockInteraction : MonoBehaviour, IInteractable
{
    public string InteractPrompt => "E";
    [SerializeField] private LockPanelInteraction lockPanel;

    public void Interact()
    {
        lockPanel.Show();
    }
}
