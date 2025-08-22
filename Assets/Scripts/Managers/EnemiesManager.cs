using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    private readonly List<GameObject> enemiesList = new();

    [SerializeField] GameEvent enemiesDefeated;
    [SerializeField] IntReference enemiesKC;
    

    private void Start()
    {
        GetAllChildren();
    }

    void GetAllChildren()
    {
        enemiesList.Clear();
        foreach (Transform child in transform)
        {
            enemiesList.Add(child.gameObject);
            child.GetComponent<EnemyPatrol>().enabled = false;

            if (child.TryGetComponent<Health>(out Health childHealth))
            {
                childHealth.onDeath += DeleteDeadEnemy;
            }
        }
    }

    public void EnableAllCHildren()
    {
        foreach (var enemies in enemiesList)
        {
            enemies.GetComponent<EnemyPatrol>().enabled = true;
        }
    }

    private void DeleteDeadEnemy(GameObject deadEnemy)
    {
        enemiesList.Remove(deadEnemy);
        enemiesKC.Value++;
        if (enemiesList.Count == 0)
        {
            enemiesDefeated.Raise();
        }
    }
}
