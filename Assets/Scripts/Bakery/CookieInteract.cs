using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieInteract : MonoBehaviour, IInteractable
{
    public string InteractPrompt => "E Eat cookie";

    public void Interact()
    {
        gameObject.SetActive(false);
    }
}
