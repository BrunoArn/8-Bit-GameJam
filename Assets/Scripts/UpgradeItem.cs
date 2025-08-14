using UnityEngine;

public class UpgradeItem : MonoBehaviour
{
    [SerializeField] private int extraDamage = 0;
    [SerializeField] private float projectileSpeedMultiplier = 0f;
    [SerializeField] private float extraMovespeed = 0f;
    [SerializeField] private float extraFireRate = 0f;
    [SerializeField] private float extraFireDistance = 0f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Upgrades>(out Upgrades upgrades))
        {
            upgrades.UpgradStats(extraDamage, projectileSpeedMultiplier, extraMovespeed, extraFireRate, extraFireDistance);
        }
    }
}
