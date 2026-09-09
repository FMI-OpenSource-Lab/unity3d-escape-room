using TMPro;
using UnityEngine;

public class MenorahInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip marbleAnim;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip moveMarblePlate;
    [SerializeField] private TextMeshProUGUI hintText;
    [SerializeField] private Transform[] candleSlots;
    [SerializeField] private GameObject candlePlaceholder;
    private Coroutine hintTextTimer;
    private bool isUnlocked;
    private int placedCandles;
    private string keyId = "candle";

    public string InteractPrompt
    {
        get
        {
            if (isUnlocked)
                return "E";
            return PlayerInventory.Instance.GetValue(keyId) > 0
                ? "Place candle"
                : "Something is missing";
        }
    }

    public void Interact()
    {
        if (!isUnlocked)
        {
            if (PlayerInventory.Instance.GetValue(keyId) <= 0)
            {
                ShowHint();
            }
            if (PlayerInventory.Instance.CheckItem(keyId))
            {
                candlePlaceholder.SetActive(true);
                PlayerInventory.Instance.RemoveItem(keyId);
                Instantiate(candlePlaceholder, candleSlots[placedCandles].position, candleSlots[placedCandles].rotation);
                placedCandles++;
                if (placedCandles == candleSlots.Length)
                {
                    isUnlocked = true;
                    animator.Play(marbleAnim.name, 0);
                    audioSource.PlayOneShot(moveMarblePlate);
                }

            }
        }
        else
            ShowHint();
    }

    private void Awake()
    {
        isUnlocked = false;
        placedCandles = 0;
        candlePlaceholder.SetActive(false);
    }
    private void ShowHint()
    {
        hintText.enabled = true;

        switch (placedCandles)
        {
            case 0:
                hintText.text = "Hmm... looks like a candle holder.";
                break;
            default:
                hintText.text = "";
                break;
        }

        if (isUnlocked)
            hintText.text = "Something opened!";

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
