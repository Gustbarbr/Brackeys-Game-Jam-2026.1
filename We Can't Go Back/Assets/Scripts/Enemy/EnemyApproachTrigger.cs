using UnityEngine;

public class EnemyApproachTrigger : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 1f;

    [Header("Detection")]
    public float triggerDistance = 0.3f;

    [Header("Fade Controller")]
    public FadeWithTextToMenu fadeController;

    private Transform player;
    private bool triggered = false;

    private void Awake()
    {
        fadeController = FindFirstObjectByType<FadeWithTextToMenu>();
    }

    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
            player = p.transform;
    }

    void Update()
    {
        if (player == null || triggered) return;

        Vector2 direction = (player.position - transform.position).normalized;

        transform.Translate(direction * speed * Time.deltaTime);

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= triggerDistance)
        {
            triggered = true;

            speed = 0f;

            if (fadeController != null)
                fadeController.StartFade();
        }
    }
}