using UnityEngine;

public class EnemyWalkSlowly : MonoBehaviour
{
    public float speed = 2f;     
    public float distance = 3f;   

    private Vector3 startPosition;
    private bool movingRight = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            if (transform.position.x >= startPosition.x + distance)
                movingRight = false;
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

            if (transform.position.x <= startPosition.x - distance)
                movingRight = true;
        }
    }
}