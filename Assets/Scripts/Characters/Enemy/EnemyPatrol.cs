
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Movement status")]
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float walkRadius = 3f;
    [SerializeField] float waitToMove = 1.5f;
    [Header("Map info")]
    [SerializeField] Tilemap tilemap;

    private Vector2 targetPosition;

    private bool isMoving = true;

    private void Start()
    {
        SetNewTargetPosition();
    }
    private void Update()
    {
        MoveTowardTarget();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.GetComponent<PlayerMovement>() || !collision.GetComponent<PlayerProjectile>())
        {
            StartCoroutine(WaitToMove());
        }
    }
    void MoveTowardTarget()
    {
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, targetPosition) < 0.3f)
            {
                StartCoroutine(WaitToMove());
            }
        }
    }

    private void SetNewTargetPosition()
    {
        Bounds bounds = tilemap.localBounds;

        Vector3 worldMin = tilemap.transform.TransformPoint(bounds.min);
        Vector3 worldMax = tilemap.transform.TransformPoint(bounds.max);

        targetPosition = GetRandomPositionNear(transform.position);
        targetPosition.x = Mathf.Clamp(targetPosition.x, worldMin.x, worldMax.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, worldMin.y, worldMax.y);
    }

    private Vector2 GetRandomPositionNear(Vector2 center)
    {
        Vector2 randomOffSet = Random.insideUnitCircle * walkRadius;
        return center + randomOffSet;
    }

    private IEnumerator WaitToMove()
    {
        isMoving = false;
        yield return new WaitForSeconds(waitToMove);
        SetNewTargetPosition();
        isMoving = true;
    }
}
