using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    private readonly List<GameObject> enemiesList = new();

    private void Start() {
        GetAllChildren();
    }

    void GetAllChildren()
    {
        enemiesList.Clear();
        foreach (Transform child in transform)
        {
            enemiesList.Add(child.gameObject);

            if (child.TryGetComponent<Health>(out Health childHealth))
            {
                childHealth.onDeath += DeleteDeadEnemy;
            }
        }
    }

    private void DeleteDeadEnemy(GameObject deadEnemy)
    {
        enemiesList.Remove(deadEnemy);
        if (enemiesList.Count == 0)
        {
            Debug.Log("acabou o futebol");
        }
    }
}
