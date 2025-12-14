using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    private int currentHealth;
    public int MaxHealth => maxHealth;
    public int CurrentHealth => currentHealth;

public System.Action OnHealthChanged;


    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
    OnHealthChanged?.Invoke();

        Debug.Log("Player HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died");
        // TODO: restart level, show game over, etc.
    }
}
