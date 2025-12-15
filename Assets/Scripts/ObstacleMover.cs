using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    private float leftBound;
    private float spriteHalfWidth;
    
    void Start()
    {
        // Cache sprite info
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        spriteHalfWidth = sr.bounds.size.x / 2f;
    }

    void Update()
    {
        float currentSpeed = ObstacleSpawner.baseSpeed + ObstacleSpawner.game_timer * ObstacleSpawner.acceleration;

        // Move obstacle
        transform.position += Vector3.left * currentSpeed * Time.deltaTime;


        // Despawn check
        Camera cam = Camera.main;
        Vector3 camPos = cam.transform.position;
        float height = cam.orthographicSize * 2f;
        float width = height * cam.aspect;
        leftBound = camPos.x - width / 2f;

        float leftEdge = transform.position.x + spriteHalfWidth;
        if (leftEdge < leftBound)
        {
            Destroy(gameObject);
        }
    }
}
