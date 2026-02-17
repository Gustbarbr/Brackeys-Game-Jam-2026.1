using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject projectilePrefab;  
    public float shootInterval = 2f;     
    public float shootForce = 10f;       

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= shootInterval)
        {
            Shoot();
            timer = 0f;
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.up * shootForce;
        }
    }
}