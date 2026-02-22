using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentPlayer : MonoBehaviour
{
    private GameObject player;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "First Level")
        {
            player = GameObject.Find("Player");

            if (player != null)
            {
                MonoBehaviour[] scripts = player.GetComponentsInChildren<MonoBehaviour>(true);
                foreach (MonoBehaviour script in scripts)
                {
                    script.enabled = true;
                }

                Renderer[] renderers = player.GetComponentsInChildren<Renderer>(true);
                foreach (Renderer r in renderers)
                {
                    r.enabled = true;
                }

                Collider[] colliders = player.GetComponentsInChildren<Collider>(true);
                foreach (Collider c in colliders)
                {
                    c.enabled = true;
                }
            }
        }
    }
}