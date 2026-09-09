using UnityEngine;

public class PaperHintInteraction : MonoBehaviour, IInteractable
{
    public string InteractPrompt => "E";
    public KeyShapesPanelInteraction keyShapePanel;

    public void Interact()
    {
        keyShapePanel.Show();
    }
}
