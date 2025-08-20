using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    [SerializeField] private AnimationCurve animCurve;
    [SerializeField] private float heightY = 1.5f;
    [SerializeField] private float popDuration = 1f;

    [SerializeField] private float pickUpDistance = 5f;
    [SerializeField] private float accelerationRate = .2f;

    [SerializeField] private Vector3 playerOffSet = new(0f, 0.5f);

    [SerializeField] TransformReferenceSO playerTransformRef;


    private Rigidbody2D rb;
    private Vector3 moveDir;
    private float moveSpeed = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<Collider2D>().enabled = false;
    }

    private void Start()
    {
        StartCoroutine(AnimCurveSpawnRoutine());
    }
    

    private void Update()
    {
        Vector3 playerPos = playerTransformRef.Value.position - playerOffSet;

        if (Vector3.Distance(transform.position, playerPos) < pickUpDistance) {
            moveDir = (playerPos - transform.position).normalized;
            moveSpeed += accelerationRate;
        } else {
            moveDir = Vector3.zero;
            moveSpeed = 0f;
        }
    }

    private void FixedUpdate() {
        rb.linearVelocity = moveSpeed * Time.fixedDeltaTime * moveDir;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
            Destroy(this.gameObject);
    }

    private IEnumerator AnimCurveSpawnRoutine()
    {
        Vector2 startPoint = transform.position;
        float randomX = transform.position.x + Random.Range(-2f, 2f);
        float randomY = transform.position.y + Random.Range(-1f, 1f);
        Vector2 endPoint = new(randomX, randomY);

        float timePassed = 0f;
        while (timePassed < popDuration)
        {
            timePassed += Time.deltaTime;
            float linearT = timePassed / popDuration;
            float heighT = animCurve.Evaluate(linearT);
            float height = Mathf.Lerp(0f, heightY, heighT);

            transform.position = Vector2.Lerp(startPoint, endPoint, linearT) + new Vector2(0f, height);
            yield return null;
        }
        GetComponent<Collider2D>().enabled = true;
    }

}
