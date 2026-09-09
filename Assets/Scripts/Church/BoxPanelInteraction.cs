using UnityEngine;
using UnityEngine.UI;

public class BoxPanelInteraction : MonoBehaviour
{
    public static BoxPanelInteraction Instance { get; private set; }
    [SerializeField] private LockNumberSlot[] slots;
    [SerializeField] private Button closeButton;
    private int[] code = { 6, 5, 1, 3 };
    public bool isUnlocked = false;
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
        //sound effect
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
