using UnityEngine;
using UnityEngine.UI;

public class ControlsPanel : MonoBehaviour
{
    public Button closeButton;

    void Update()
    {
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
