using UnityEngine;

[System.Serializable]
public class DropItem
{
    public GameObject item;
    [Range(0f, 100f)]
    public float dropChance;
}
