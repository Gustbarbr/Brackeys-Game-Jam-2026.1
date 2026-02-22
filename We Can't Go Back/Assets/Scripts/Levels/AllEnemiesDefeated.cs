using UnityEngine;

public class AllEnemiesDefeated : MonoBehaviour
{
    [SerializeField] private GameObject specialEnemy;

    private int initialEnemyCount;
    private bool specialSpawned = false;

    void Start()
    {
        initialEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    void Update()
    {
        if (specialSpawned) return;

        int currentEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (initialEnemyCount > 0 && currentEnemies == 0)
        {
            SpawnSpecialEnemy();
            specialSpawned = true;
        }
    }

    void SpawnSpecialEnemy()
    {
        GameObject spawnPoint = GameObject.FindGameObjectWithTag("SpecialSpawn");

        if (spawnPoint == null)
        {
            return;
        }

        Instantiate(specialEnemy, spawnPoint.transform.position, Quaternion.identity);
    }
}