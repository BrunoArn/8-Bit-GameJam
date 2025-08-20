
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
    [SerializeField] Vector2 borderOffSetPositive;
    [SerializeField] Vector2 borderOffSetNegative;

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

        BoundsInt bounds = tilemap.cellBounds;

        Vector3 worldMin = tilemap.transform.TransformPoint(bounds.min);
        Vector3 worldMax = tilemap.transform.TransformPoint(bounds.max);

        var nextTargetPosition = GetRandomPositionNear(transform.position);
        //Debug.Log($"target position is: [{targetPosition.x}] X, [{targetPosition.y}] Y");
        nextTargetPosition.x = Mathf.Clamp(nextTargetPosition.x, worldMin.x + borderOffSetPositive.x, worldMax.x - borderOffSetNegative.x);
        nextTargetPosition.y = Mathf.Clamp(nextTargetPosition.y, worldMin.y + borderOffSetPositive.y, worldMax.y - borderOffSetNegative.y);
        //Debug.Log($"world position is [minX {worldMin.x}, maxX {worldMax.x}], [minY{worldMin.y}, maxY {worldMax.y}]\n");
        //Debug.Log($"target position after clamp is: [{targetPosition.x}] X, [{targetPosition.y}] Y");
        if (IsPathClear(transform.position, nextTargetPosition))
        {
            targetPosition = nextTargetPosition;
        }
        else
        {
            SetNewTargetPosition();
        }
    }

    private bool IsPathClear(Vector2 from, Vector2 to)
    {
        Vector2 direction = to - from;
        float distance = direction.magnitude;

        RaycastHit2D hit = Physics2D.Raycast(from, direction.normalized, distance, LayerMask.GetMask("Ground"));
        Debug.DrawLine(from, to, Color.green);

        return hit.collider == null;
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
