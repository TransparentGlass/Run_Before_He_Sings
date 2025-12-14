using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    public float speed = 5f;

    private float leftBound;
    private float spriteHalfWidth;
    float game_time = ObstacleSpawner.game_timer;

    void Start()
    {
        // Cache sprite info
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        spriteHalfWidth = sr.bounds.size.x / 2f;

        // Cache camera bounds
        Camera cam = Camera.main;
        Vector3 camPos = cam.transform.position;

        float height = cam.orthographicSize * 2f;
        float width = height * cam.aspect;

        leftBound = camPos.x - width / 2f;
    }

    void Update()
    {
        // Move
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Despawn check
        float leftEdge = transform.position.x + spriteHalfWidth;

        if (leftEdge < leftBound)
        {
            
            Destroy(gameObject);
        }
    }
}
