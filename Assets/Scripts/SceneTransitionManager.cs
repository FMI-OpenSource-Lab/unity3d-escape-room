using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance { get; private set; }
    private string pendingSpawnId;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void TransitionToScene(string sceneName, string spawnId)
    {
        pendingSpawnId = spawnId;
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneName);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        PositionPlayerAtSpawn(pendingSpawnId);
    }

    private void PositionPlayerAtSpawn(string spawnId)
    {
        SpawnPoint[] spawnPoints = FindObjectsByType<SpawnPoint>();

        foreach (var sp in spawnPoints)
        {
            if (sp.spawnId == spawnId)
            {
                PlayerActionsManager2 player = PlayerActionsManager2.Instance;
                player.transform.SetPositionAndRotation(sp.transform.position, sp.transform.rotation);
                return;
            }
        }

    }
}
