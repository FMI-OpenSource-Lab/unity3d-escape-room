using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance { get; private set; }
    private Dictionary<string, int> Inventory = new Dictionary<string, int>();

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    public void AddItem(string key)
    {
        int value = 1;
        if (Inventory.ContainsKey(key))
        {
            value += Inventory.GetValueOrDefault(key);
            Inventory.Remove(key);
            Inventory.Add(key, value);
        }
        else
            Inventory.Add(key, value);
    }

    public void AddMultiple(string key, int value)
    {
        Inventory.Add(key, value);
    }

    public bool CheckItem(string key)
    {
        if (Inventory.ContainsKey(key))
            return true;
        else
            return false;
    }

    public int GetValue(string key)
    {
        return Inventory.GetValueOrDefault(key);
    }

    public void RemoveItem(string key)
    {
        if (Inventory.ContainsKey(key))
        {
            if (Inventory.GetValueOrDefault(key) > 1)
            {
                int tempValue = Inventory.GetValueOrDefault(key) - 1;
                Inventory.Remove(key);
                Inventory.Add(key, tempValue);
            }
            else 
                Inventory.Remove(key);
        }
    }

}
