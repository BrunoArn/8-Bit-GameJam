using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    private readonly List<GameObject> enemiesList = new();

    void GetAllChildren()
    {
        enemiesList.Clear();
        foreach (Transform child in transform)
        {
            enemiesList.Add(child.gameObject);
        }
    }
}
