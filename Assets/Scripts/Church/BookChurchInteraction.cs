using UnityEngine;
using UnityEngine.UI;

public class BookChurchInteraction : MonoBehaviour, IInteractable
{
    public string InteractPrompt => "E";
    public BookSnippetsPanel bookPanel;

    public void Interact()
    {
        bookPanel.Show(gameObject.name);
    }


}
