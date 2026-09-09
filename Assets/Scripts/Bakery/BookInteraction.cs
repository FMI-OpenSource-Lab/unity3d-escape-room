using UnityEngine;
using UnityEngine.UI;

public class BookInteraction : MonoBehaviour, IInteractable
{
    public string InteractPrompt => "E Read book";
    public BookPanel bookPanel;

    public void Interact()
    {
        bookPanel.Show();
    }


}
