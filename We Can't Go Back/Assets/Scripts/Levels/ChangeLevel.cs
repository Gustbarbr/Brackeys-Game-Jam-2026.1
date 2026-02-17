using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;

            if (sceneName == "First Level")
            {
                PlayerMovement player = collision.GetComponent<PlayerMovement>();
                player.currentLevel = 2;

                SceneManager.LoadScene("Second Level");
            }

            if (sceneName == "Second Level")
            {
                PlayerMovement player = collision.GetComponent<PlayerMovement>();
                player.currentLevel = 3;

                SceneManager.LoadScene("Third Level");
            }
        }
    }
}
