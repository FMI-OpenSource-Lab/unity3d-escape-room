using TMPro;
using UnityEngine;

public class DoorInteraction : MonoBehaviour, IInteractable
{
    public string InteractPrompt => "E Open";
    private string keyId = "Bakery door key";
    [SerializeField] public TextMeshProUGUI hintText;
    private Coroutine hintTextTimer;
    [SerializeField] private Animator doorAnim;
    public void Interact()
    {
        if (PlayerInventory.Instance.CheckItem(keyId))
        {
            doorAnim.Play("DoorOpen", 0);
            PlayerInventory.Instance.RemoveItem(keyId);
            gameObject.layer = 0;
        }
        else
            ShowHint();
    }

    private void ShowHint()
    {
        hintText.text = "Door is locked. I need to find a key.";
        if (hintTextTimer != null)
            StopCoroutine(hintTextTimer); //no overlapping

        hintTextTimer = StartCoroutine(HideTextDelay(2f));
        
    }

    private System.Collections.IEnumerator HideTextDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        hintText.enabled = false;
    }

}
