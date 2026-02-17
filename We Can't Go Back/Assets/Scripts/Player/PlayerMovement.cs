using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;

    [Header("Level Settings")]
    public int currentLevel = 1;

    private static PlayerMovement instance;

    private InputAction moveAction;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    public GameObject spawnPoint;

    private void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        transform.position = spawnPoint.transform.position;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        rb = GetComponent<Rigidbody2D>();

        moveAction = new InputAction("Move", InputActionType.Value);
        moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");

        moveAction.AddBinding("<Gamepad>/leftStick");
    }

    private void OnEnable()
    {
        moveAction.Enable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        moveAction.Disable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject spawn = GameObject.FindGameObjectWithTag("SpawnPoint");

        if (spawn != null)
        {
            transform.position = spawn.transform.position;
        }
    }

    private void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float horizontal = moveInput.x;
        float vertical = (currentLevel == 1 || currentLevel == 2) ? moveInput.y : 0f;

        Vector2 movement = new Vector2(horizontal, vertical);
        rb.linearVelocity = movement * speed;
    }
}
