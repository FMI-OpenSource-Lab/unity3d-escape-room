using UnityEngine;

public class PickUpInteraction : MonoBehaviour, IInteractable
{
    public string InteractPrompt => "E Pick up";
    private string key = "candle";

    public void Interact()
    {
        if(gameObject.name.Contains(key))
        {
            PlayerInventory.Instance.AddItem(key);
        }
        else
            PlayerInventory.Instance.AddItem(gameObject.name);

        gameObject.SetActive(false);
    }
}
