using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassCoverInteract : MonoBehaviour
{
    public void OpenGlassCover()
    {
        gameObject.SetActive(false); // Simply deactivate the glass cover
        Debug.Log("Glass cover opened");
    }
}
