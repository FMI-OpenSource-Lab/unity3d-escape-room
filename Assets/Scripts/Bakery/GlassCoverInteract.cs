using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassCoverInteract : MonoBehaviour, IInteractable
{
    public string InteractPrompt => "E Open";

    public void Interact()
    {
        gameObject.SetActive(false);
    }
    
}
