using TMPro;
using UnityEngine;

public class KeyHooksInteraction : MonoBehaviour, IInteractable
{
    public string InteractPrompt => "E";
    [SerializeField] private Transform[] keyPositions;
    [SerializeField] private GameObject[] keys;
    [SerializeField] private TextMeshProUGUI hintText;
    private Coroutine hintTextTimer;
    private int foundKeys;

    private void Awake()
    {
        foundKeys = 0;
    }
    public void Interact()
    {
       
        foreach (GameObject item in keys)
        {
            if (PlayerInventory.Instance.CheckItem(item.name))
            {
                PlayerInventory.Instance.RemoveItem(item.name);
                foreach (Transform position in keyPositions)
                {
                    if (position.name.Contains(item.name))
                    {
                        foundKeys++;
                        item.SetActive(true);
                        item.layer = 0;
                        item.transform.position = position.position;
                        item.transform.rotation = position.rotation;
                    }
                }
            }
            else 
                ShowHint();
        }
    }

    private void ShowHint()
    {
        hintText.enabled = true;

        switch (foundKeys)
        {
            case 0:
                hintText.text = "Maybe keys were stored here.";
                break;
            case 5:
                hintText.text = "I should pay attention to those shapes";
                break;
            default:
                hintText.text = "";
                break;
        }

        if (hintTextTimer != null)
            StopCoroutine(hintTextTimer);

        hintTextTimer = StartCoroutine(HideTextDelay(2f));
    }

    private System.Collections.IEnumerator HideTextDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        hintText.enabled = false;
        hintTextTimer = null;
    }
}
