using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieInteract : MonoBehaviour
{
    public void EatCookie()
    {
        gameObject.SetActive(false); // Simply deactivate the cookie
        Debug.Log("Cookie eaten");
    }
}
