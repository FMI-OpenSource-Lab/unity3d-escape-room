using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BookPanel : MonoBehaviour
{
    public Button closeButton;

    void Start() 
    {
        gameObject.SetActive(false);
        closeButton.onClick.AddListener(Hide);
    }

    public void Show()
    {
        gameObject.SetActive(true);
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
