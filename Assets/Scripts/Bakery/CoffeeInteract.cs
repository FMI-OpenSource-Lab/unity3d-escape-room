using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeInteract : MonoBehaviour, IInteractable
{
    public string InteractPrompt => "E Drink coffee";

    public void Interact()
    {
        gameObject.SetActive(false);
    }
}
