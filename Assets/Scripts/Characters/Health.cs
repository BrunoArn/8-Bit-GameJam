using System;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 6;

    public event Action onTakeDamage;
    public event Action<GameObject> onDeath;
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
            onDeath?.Invoke(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void Heal(int amount)
    {
        if ((currentHealth + amount) > maxHealth) return;

        currentHealth += amount;
        onTakeDamage?.Invoke();
    }

    public void RaiseMaxHealth(int amount)
    {
        maxHealth += amount;
        onRaiseMaxHealth?.Invoke();
    }
}
