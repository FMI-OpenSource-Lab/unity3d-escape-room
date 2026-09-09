using UnityEngine;
using UnityEngine.UI;

public class LockPanelInteraction : MonoBehaviour
{
    public static LockPanelInteraction Instance { get; private set; }
    [SerializeField] private LockNumberSlot[] slots;
    [SerializeField] private Button closeButton;
    [SerializeField] private GameObject padlock;
    private int[] code = { 8, 5, 1, 2, 7 };
    internal bool isUnlocked;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        foreach (var slot in slots)
            slot.OnDigitChanged += CheckCode;
    }

    private void CheckCode()
    {
        if (isUnlocked) return;

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].CurrentDigit != code[i])
                return;
        }

        isUnlocked = true;
        padlock.SetActive(false);
        Hide();
    }
    void Start() => gameObject.SetActive(false);

    public void Show()
    {
        if (isUnlocked)
            return;
        gameObject.SetActive(true);
        closeButton.onClick.AddListener(Hide);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PlayerActionsManager2.Instance.SetCanLook(false);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerActionsManager2.Instance.SetCanLook(true);
    }
}
