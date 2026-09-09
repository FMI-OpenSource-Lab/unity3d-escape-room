using TMPro;
using UnityEngine;

public class WallSymbolInteraction : MonoBehaviour, IInteractable
{
    public string InteractPrompt => "";
    [SerializeField] private TextMeshProUGUI hintText;
    private Coroutine hintTextTimer;

    public void Interact()
    {
        ShowHint();
    }
    private void ShowHint()
    {
       hintText.text = "Hmm...a symbol?";

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
