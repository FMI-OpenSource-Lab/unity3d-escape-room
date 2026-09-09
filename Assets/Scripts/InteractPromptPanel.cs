using TMPro;
using UnityEngine;

public class InteractPromptPanel : MonoBehaviour
{
    public static InteractPromptPanel Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI promptText;

    void Start() => gameObject.SetActive(false);

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void Show(string message)
    {
        promptText.text = message;
        gameObject.SetActive(true);
    }

    public void Hide() => gameObject.SetActive(false);
}
