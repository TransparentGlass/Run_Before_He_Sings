using UnityEngine;

public class Barney : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float acceleration = 0f;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       speed += acceleration * Time.deltaTime;
    }
    void FixedUpdate()
    {
        // Move player using physics
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
    }
    
}

