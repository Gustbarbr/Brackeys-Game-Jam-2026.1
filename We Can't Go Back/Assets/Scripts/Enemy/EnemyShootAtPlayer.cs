using UnityEngine;

public class EnemyShootAtPlayer : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 1f;

    [SerializeField] private bool isSpecialEnemy = false;

    private Transform player;
    private float nextFireTime;

    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");

        if (p != null)
            player = p.transform;
    }

    void Update()
    {
        if (player == null) return;

        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        Vector2 direction = player.position - firePoint.position;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Projectile proj = bullet.GetComponent<Projectile>();

        if (proj != null)
        {
            proj.SetDirection(direction);
            proj.isFromSpecialEnemy = isSpecialEnemy;
        }
    }
}