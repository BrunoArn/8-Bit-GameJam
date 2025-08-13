using System;
using Unity.Mathematics;
using UnityEngine;

public class SpawnPickUp : MonoBehaviour
{
    [SerializeField] Health objectHealth;
    [SerializeField] GameObject itemPrefab;
    void OnEnable()
    {
        objectHealth.onDeath += spawnItem;
    }

    private void spawnItem()
    {
        Instantiate(itemPrefab, transform.position, quaternion.identity);
    }
}
