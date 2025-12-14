using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    

    private float leftBound;
    private float spriteHalfWidth;
    float game_time = ObstacleSpawner.game_timer;

    private static float speed;
    private static float acceleration;

    void Start()
    {
        // Cache sprite info
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        spriteHalfWidth = sr.bounds.size.x / 2f;
        speed = ObstacleSpawner.speed;
        acceleration = ObstacleSpawner.acceleration;

        // Cache camera bounds
       
    }

    void Update()
    {
        Camera cam = Camera.main;
        Vector3 camPos = cam.transform.position;

        float height = cam.orthographicSize * 2f;
        float width = height * cam.aspect;

        leftBound = camPos.x - width / 2f;
        // Move
        speed += acceleration * Time.deltaTime;
        

        // Despawn check
        float leftEdge = transform.position.x + spriteHalfWidth;
        if (leftEdge < leftBound)
        {
            
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
