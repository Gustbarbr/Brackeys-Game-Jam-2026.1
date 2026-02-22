using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;

    public bool isFromSpecialEnemy = false;

    private Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth player = collision.GetComponent<PlayerHealth>();

            if (player != null)
            {
                if (isFromSpecialEnemy)
                {
                    player.deathBySpecialEnemy = true;
                }

                player.TakeDamage(damage);
            }
        }

        if (collision.CompareTag("Enemy"))
        {
            EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
            if (enemy != null)
                enemy.TakeDamage(damage);
        }

        if (!collision.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}