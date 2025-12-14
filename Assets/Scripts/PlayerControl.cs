using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5f;
    public float acceleration = 1.2f;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        speed += acceleration * Time.deltaTime;
        transform.Translate(new Vector2(1f, 0f) *speed* Time.deltaTime);

        if (Input.GetKey(KeyCode.Space));
    }

    void Jump()
    {
        
    }
}

  