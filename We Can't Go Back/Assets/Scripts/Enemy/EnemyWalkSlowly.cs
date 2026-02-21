using UnityEngine;

public class EnemyWalkSlowly : MonoBehaviour
{
    public float speed = 1f;
    public float maxY;

    void Update()
    {
        if (transform.position.y < maxY)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }
}
