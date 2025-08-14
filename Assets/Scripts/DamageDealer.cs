using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health health) && collision.GetComponent<PlayerController>())
        {
            health.TakeDamage(damage);
        }
    }
}
