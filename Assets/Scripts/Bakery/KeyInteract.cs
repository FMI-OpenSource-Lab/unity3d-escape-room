using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteract : MonoBehaviour, IInteractable
{
    public string InteractPrompt => "E";
    [SerializeField] private GameObject keyId;

    public void Interact()
    {
        gameObject.SetActive(false);
        PlayerInventory.Instance.AddItem(keyId.name);
    }

}
