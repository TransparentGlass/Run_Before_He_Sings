using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    

    private PlayerHealth health;

    void Awake()
    {
        health = GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            health.TakeDamage(damage);
        }
    }
}
