using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnPickUp : MonoBehaviour
{
    [SerializeField] Health objectHealth;

    [SerializeField] List<DropItem> dropTable;

    void OnEnable()
    {
        objectHealth.onDeath += LootRoll;
    }

    private void SpawnItem(GameObject itemPrefab)
    {
        Instantiate(itemPrefab, transform.position, quaternion.identity);

    }

    private void LootRoll(GameObject deadObject)
    {
        foreach (var drops in dropTable)
        {
            float roll = UnityEngine.Random.Range(0, 100);
            if (roll <= drops.dropChance)
            {
                SpawnItem(drops.item);
            }
        }
    }
}
