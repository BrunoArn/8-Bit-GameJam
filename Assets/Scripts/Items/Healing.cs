using UnityEngine;

public class Healing : MonoBehaviour
{
    [SerializeField] private int amount;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health health))
        {
            health.Heal(amount);
        }
    }
}