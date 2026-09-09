using UnityEngine;

public class LevelTransition : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private string spawnId;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        SceneTransitionManager.Instance.TransitionToScene(sceneName, spawnId);
    }
}
