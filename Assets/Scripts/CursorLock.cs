using UnityEngine;

public class CursorLock : MonoBehaviour
{
    [SerializeField] private GameObject centerPoint;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        centerPoint.SetActive(true);
    }

}
