
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
        Debug.Log($"mininmo é [{worldMin.x}x] e [{worldMin.y}y]");
        Debug.Log($"maximo é [{worldMax.x}x] e [{worldMax.y}y]");

        float x = Random.Range(worldMin.x - 0.5f, worldMax.x - 0.5f);
        float y = Random.Range(worldMin.y - 0.5f, worldMax.y - 0.5f);
        
        targetPosition = new Vector2(x, y);
    }
}
