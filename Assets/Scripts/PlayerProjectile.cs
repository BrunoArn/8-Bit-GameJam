using Unity.VisualScripting;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public int damage = 1;
    public float projectileSpeed = 12f;
    [SerializeField] float projectileRange = 10f;

    private Vector2 startPosition;
    void Start()
    {
        startPosition = transform.position;

    }

    void Update()
    {
        MoveProjectile();
        DetectProjectileDistance();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out Health enemyHealth) && !collision.GetComponent<PlayerMovement>())
        {
            enemyHealth.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }

    public void UpdateProjectileInfo(int extraDamage, float speedMultiplier, float extraProjectileRange)
    {
        damage += extraDamage;
        projectileSpeed *= speedMultiplier;
        projectileRange += extraProjectileRange;
    }

     private void MoveProjectile()
    {
        transform.transform.Translate(Vector3.right * Time.deltaTime * projectileSpeed);
    }

    private void DetectProjectileDistance()
    {
        if (Vector3.Distance(transform.position, startPosition) > projectileRange)
        {
            Destroy(this.gameObject);
        }
    }

}
