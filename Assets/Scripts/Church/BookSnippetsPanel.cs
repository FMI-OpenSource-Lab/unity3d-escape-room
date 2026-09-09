using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BookSnippetsPanel : MonoBehaviour
{
    [SerializeField] private Button closeButton;
    [SerializeField] private TextMeshProUGUI bookText;
    [SerializeField] private ScrollRect scrollRect;

    void Start()
    {
        gameObject.SetActive(false);
        closeButton.onClick.AddListener(Hide);
    }

    public void Show(string name)
    {
        gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PlayerActionsManager2.Instance.SetCanLook(false);
        if (BookSnippets.Instance.CheckKey(name))
            bookText.text = BookSnippets.Instance.GetText(name);

        LayoutRebuilder.ForceRebuildLayoutImmediate(bookText.rectTransform);
        scrollRect.verticalNormalizedPosition = 1f;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerActionsManager2.Instance.SetCanLook(true);
    }

}