using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeInteract : MonoBehaviour
{
    public void DrinkCoffee()
    {
        gameObject.SetActive(false); // Simply deactivate the coffee cup
        Debug.Log("Coffee drunk");
    }
}
