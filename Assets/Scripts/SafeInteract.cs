using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeInteract : MonoBehaviour
{
    public string correctPassword = "836";
    public GameObject safeClosed;
    public GameObject safeOpened;

    void Start()
    {
        if (safeClosed == null || safeOpened == null)
        {
            Debug.LogError("SafeClosed or SafeOpened GameObject is not assigned in the Inspector");
        }
    }

    public void TryOpenSafe(string enteredPassword)
    {
        Debug.Log("TryOpenSafe called with password: " + enteredPassword); // Debug log
        if (enteredPassword == correctPassword)
        {
            Debug.Log("Password is correct"); // Debug log
            OpenSafe();
        }
        else
        {
            Debug.Log("Incorrect password"); // Debug log
        }
    }

    void OpenSafe()
    {
        if (safeClosed != null && safeOpened != null)
        {
            safeClosed.SetActive(false);
            safeOpened.SetActive(true);
            Debug.Log("Safe opened"); // Debug log
        }
        else
        {
            Debug.LogError("SafeClosed or SafeOpened GameObject is not assigned in the Inspector");
        }
    }
}
