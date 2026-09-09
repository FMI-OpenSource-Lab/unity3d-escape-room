using System;
using UnityEngine;
using UnityEngine.UI;

public class LockNumberSlot : MonoBehaviour
{
    [SerializeField] private Image digitImage;
    [SerializeField] private Sprite[] digitSprites;
    [SerializeField] private Button changeDigitBtn;
    private int currentDigit;
    public int CurrentDigit => currentDigit;
    public event Action OnDigitChanged;

    private void Awake()
    {
        changeDigitBtn.onClick.AddListener(CycleDigit);
    }
    void Start()
    {
        UpdateSprite();
    }

    private void CycleDigit()
    {
        currentDigit = (currentDigit + 1) % digitSprites.Length;
        UpdateSprite();
        OnDigitChanged.Invoke();
    }

    private void UpdateSprite()
    {
        digitImage.sprite = digitSprites[currentDigit];
    }
}
