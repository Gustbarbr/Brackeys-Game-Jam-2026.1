using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public bool deathBySpecialEnemy = false;

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

        if (sceneName == "Third Level" && !deathBySpecialEnemy)
        {
            SceneManager.LoadScene("Third Level");
        }
        else if (sceneName == "Third Level" && deathBySpecialEnemy)
        {
            deathBySpecialEnemy = false;
            SceneManager.LoadScene("Fourth Level");
        }
        else if (sceneName == "Fourth Level")
        {
            SceneManager.LoadScene("Fourth Level");
        }

        currentHealth = maxHealth;
    }
}