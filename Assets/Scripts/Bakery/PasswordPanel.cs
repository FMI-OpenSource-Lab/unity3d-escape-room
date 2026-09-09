using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasswordPanel : MonoBehaviour
{
    public TextMeshProUGUI hintText;
    public TMP_InputField passwordInputField;
    public string correctPassword = "836";
    public GameObject safeClosed;
    public GameObject safeOpened;
    public Button submitButton, closeButton;
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        hintText.text = "Hmm.. seems like someone is trying to open the safe. If you are that curious why don't you go eat some cookies or drink some coffee or maybe even read a book. You might find something interesting there.";
        passwordInputField.ActivateInputField();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PlayerActionsManager2.Instance.SetCanLook(false);
        submitButton.onClick.AddListener(SubmitPassword);
        closeButton.onClick.AddListener(Hide);
    }

    public void SubmitPassword()
    {
        string enteredPassword = passwordInputField.text;
        TryOpenSafe(enteredPassword);
    }

    public void TryOpenSafe(string enteredPassword)
    {
        if (enteredPassword == correctPassword)
        { 
            OpenSafe();
            Hide();
        }
        else
        {
            passwordInputField.text = "";
            Debug.Log("Incorrect password"); // Debug log
        }
    }

    void OpenSafe()
    {
        if (safeClosed != null && safeOpened != null)
        {
            safeClosed.SetActive(false);
            safeOpened.SetActive(true);
        }
        else
        {
            Debug.LogError("SafeClosed or SafeOpened GameObject is not assigned in the Inspector");
        }
    }
    void Hide()
    {
        gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerActionsManager2.Instance.SetCanLook(true);
    }

}






