using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public int damage = 1;
    public float projectileSpeed = 12f;
    [SerializeField] float projectileRange = 10f;
    [SerializeField] private GameObject particle;
    [SerializeField] private float minScaleFactor = 0.5f;
    
    private Vector2 startPosition;
    private Vector3 initialScale;

    void Start()
    {
        startPosition = transform.position;
        initialScale = transform.localScale;
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
            Instantiate(particle, transform.position, quaternion.identity);
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
        transform.transform.Translate(projectileSpeed * Time.deltaTime * Vector3.right);
    }

    private void DetectProjectileDistance()
    {
        //rezise projectile with distance reference
        float distance = Vector3.Distance(startPosition, transform.position);
        float normalizeDistance = Mathf.Clamp01(distance / projectileRange);
        float scaleFactor = Mathf.Lerp(1f, minScaleFactor, normalizeDistance);

        transform.localScale = initialScale * scaleFactor; 

        if (distance > projectileRange)
        {
            //Instantiate(particle, transform.position, quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
