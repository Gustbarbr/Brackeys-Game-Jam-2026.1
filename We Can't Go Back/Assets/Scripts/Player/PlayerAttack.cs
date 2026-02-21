using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    public GameObject attackPrefab;
    public Transform attackSpawnPoint;

    private InputAction attackAction;

    private void Awake()
    {
        attackAction = new InputAction("Attack", InputActionType.Button);
        attackAction.AddBinding("<Keyboard>/space");
    }

    private void OnEnable()
    {
        attackAction.Enable();
    }

    private void OnDisable()
    {
        attackAction.Disable();
    }

    private void Update()
    {
        if (attackAction.WasPressedThisFrame())
        {
            Attack();
        }
    }

    void Attack()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if(sceneName == "Third Level" || sceneName == "Fourth Level")
        {
            GameObject attack = Instantiate(
            attackPrefab,
            attackSpawnPoint.position,
            Quaternion.identity
            );

            Projectile projectile = attack.GetComponent<Projectile>();

            if (projectile != null)
            {
                projectile.SetDirection(Vector2.down);
            }
        }
    }
}