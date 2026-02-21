using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllEnemiesDefeated : MonoBehaviour
{
    public GameObject thirdLevelSpecialEnemy;
    public GameObject fourthLevelSpecialEnemy;

    private bool specialSpawned = false;

    void Update()
    {
        if (specialSpawned) return;

        if (EnemiesDefeated())
        {
            SpawnSpecialEnemy();
            specialSpawned = true;
        }
    }

    bool EnemiesDefeated()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length == 0;
    }

    void SpawnSpecialEnemy()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Third Level")
        {
            Instantiate(thirdLevelSpecialEnemy, transform.position, Quaternion.identity);
            EnemyHealth thirdLevelSpecialEnemyHp = thirdLevelSpecialEnemy.GetComponent<EnemyHealth>();
            if(thirdLevelSpecialEnemyHp.currentHealth <= 0)
            {
                SceneManager.LoadScene("Fourth Level");
            }
        }
        else if (sceneName == "Fourth Level")
        {
            Instantiate(fourthLevelSpecialEnemy, transform.position, Quaternion.identity);
        }
    }
}
