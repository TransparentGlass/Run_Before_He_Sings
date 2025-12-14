using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Image heartPrefab;
    [SerializeField] private Transform heartParent;

    private List<Image> hearts = new();

    void Start()
    {
        playerHealth.OnHealthChanged += UpdateHearts;
        CreateHearts();
        UpdateHearts();
    }

    void CreateHearts()
    {
        for (int i = 0; i < playerHealth.MaxHealth; i++)
        {
            Image heart = Instantiate(heartPrefab, heartParent);
            heart.gameObject.SetActive(true);   
            heart.enabled = true;
            hearts.Add(heart);
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            hearts[i].enabled = i < playerHealth.CurrentHealth;
        }
    }
}
