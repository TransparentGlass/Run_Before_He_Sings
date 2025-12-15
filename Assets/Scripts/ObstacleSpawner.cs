using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Obstacle Settings")]
    public GameObject[] obstaclePrefabs;
    [SerializeField] private Transform ground; // assign your ground in inspector
    [SerializeField] public static float baseSpeed = 5f;       // starting speed
    [SerializeField] public static float acceleration = 0.05f; // speed increase per second
    [SerializeField] private float minDelay = 1.5f;
    [SerializeField] private float maxDelay = 3f;

    private float obstacleTimer;
    private float nextSpawn;

    public static float game_timer { get; private set; }

    private Camera cam;
    private float height;
    private float width;
    private float rightEdge;

    void Awake()
    {
        game_timer = 0f;
    }

    void Start()
    {
        cam = Camera.main;
        nextSpawn = Random.Range(minDelay, maxDelay);
    }

    void Update()
    {
        // Update game timer
        game_timer += Time.deltaTime;
        obstacleTimer += Time.deltaTime;

        // Update camera bounds
        height = cam.orthographicSize * 2f;
        width = height * cam.aspect;
        rightEdge = cam.transform.position.x + width / 2f;

        // Spawn obstacle if timer reached
        if (obstacleTimer >= nextSpawn)
        {
            obstacleTimer = 0f;
            nextSpawn = Random.Range(minDelay, maxDelay);
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject prefab = GetRandomObstacle();
        GameObject go = Instantiate(prefab);

        // Get obstacle height offset (pivot at center)
        SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
        float yOffset = sr != null ? sr.bounds.size.y / 2f : 0f;

        // Get top of ground
        Collider2D groundCollider = ground.GetComponent<Collider2D>();
        float groundTop = groundCollider != null ? groundCollider.bounds.max.y : ground.position.y;

        // Place obstacle so its bottom aligns with ground top
        go.transform.position = new Vector3(
            rightEdge + 5f,       // spawn just offscreen
            groundTop + yOffset,   // align with top of ground
            0f
        );
    }

    public GameObject GetRandomObstacle()
    {
        int index = Random.Range(0, obstaclePrefabs.Length);
        return obstaclePrefabs[index];
    }
}
