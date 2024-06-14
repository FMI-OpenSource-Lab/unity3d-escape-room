using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteract : MonoBehaviour
{
    public GameObject congratsPanel;

    public void PickUpKey()
    {
        gameObject.SetActive(false); // Make the key disappear
        congratsPanel.SetActive(true); // Show the congratulations panel
    }
}
