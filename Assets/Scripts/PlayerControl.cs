using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float acceleration = 0f;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Increase speed over time
        speed += acceleration * Time.deltaTime;

        // Ground check
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundRadius,
            groundLayer
        );

        // Jump input
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // Move player using physics
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
}
