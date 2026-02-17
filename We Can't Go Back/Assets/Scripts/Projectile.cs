using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector3.up * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Player"))
        {
            PlayerHealth player = collision.GetComponent<PlayerHealth>();

            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }
}
