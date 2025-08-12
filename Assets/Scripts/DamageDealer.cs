using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int Damage;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(Damage);
        }
        
    }
}
