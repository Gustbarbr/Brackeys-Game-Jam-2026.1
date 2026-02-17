using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        currentHealth = maxHealth;

        if (sceneName == "Third Level")
        {
            SceneManager.LoadScene("Third Level");
        }

        if (sceneName == "Fourth Level")
        {
            SceneManager.LoadScene("Fourth Level");
        }
    }
}