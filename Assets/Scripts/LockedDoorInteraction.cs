using TMPro;
using UnityEngine;

public class LockedDoorInteraction : MonoBehaviour, IInteractable
{
	public string InteractPrompt => "E";
	[SerializeField] private GameObject keyId;
	[SerializeField] private Animator doorAnim;
	[SerializeField] private AnimationClip animation;
	[SerializeField] public TextMeshProUGUI hintText;
	private Coroutine hintTextTimer;

	public void Interact()
	{
		if (PlayerInventory.Instance.CheckItem(keyId.name))
		{
			doorAnim.Play(animation.name, 0);
			PlayerInventory.Instance.RemoveItem(keyId.name);
			gameObject.layer = 0;
		}
		else
			ShowHint();
	}
	private void ShowHint()
	{
		hintText.text = "Door is locked. I need to find a key.";
		if (hintTextTimer != null)
			StopCoroutine(hintTextTimer);

		hintTextTimer = StartCoroutine(HideTextDelay(2f));

	}

	private System.Collections.IEnumerator HideTextDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		hintText.enabled = false;
	}
}
