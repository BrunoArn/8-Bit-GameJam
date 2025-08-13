
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] Tilemap tilemap;
    private Vector2 targetPosition;

    private void Start()
    {
        SetNewTargetPosition();
    }
    private void Update()
    {
        MoveTowardTarget();
    }
    void MoveTowardTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetNewTargetPosition();
        }


    }

    private void SetNewTargetPosition()
    {
        Bounds bounds = tilemap.localBounds;

        Vector3 worldMin = tilemap.transform.TransformPoint(bounds.min);
        Vector3 worldMax = tilemap.transform.TransformPoint(bounds.max);

        float x = Random.Range(worldMin.x, worldMax.x);
        float y = Random.Range(worldMin.y, worldMax.y);
        
        targetPosition = new Vector2(x, y);
    }
}
