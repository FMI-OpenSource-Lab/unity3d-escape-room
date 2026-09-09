using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeInteract : MonoBehaviour,IInteractable
{
    public GameObject safeClosed;
    public GameObject safeOpened;
    public PasswordPanel passwordPanel;
    public string InteractPrompt => "E Open";

    void Start()
    {
        if (safeClosed == null || safeOpened == null)
        {
            Debug.LogError("SafeClosed or SafeOpened GameObject is not assigned in the Inspector");
        }
    }

    public void Interact()
    {
        passwordPanel.Show();
    }

}
