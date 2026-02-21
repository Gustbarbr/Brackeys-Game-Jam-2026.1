using UnityEngine;

public class EnemyShaking : MonoBehaviour
{
    public float speed; 
    public float distance;   

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float movement = Mathf.Sin(Time.time * speed) * distance;
        transform.position = new Vector3(
            startPosition.x + movement,
            transform.position.y,
            transform.position.z
        );
    }
}
