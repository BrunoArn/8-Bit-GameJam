using System;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 6;

    public event Action onTakeDamage;
    public event Action onDeath;
    public event Action onRaiseMaxHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        onTakeDamage?.Invoke();

        if (currentHealth <= 0)
        {
            onDeath?.Invoke();
            Destroy(this.gameObject);
        }
    }

    public void RaiseMaxHealth(int amount)
    {
        maxHealth += amount;
        onRaiseMaxHealth?.Invoke();
    }
}
