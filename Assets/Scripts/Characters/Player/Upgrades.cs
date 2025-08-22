using System;
using UnityEngine;

public enum UpgradeType { damage, projectileSpeed, fireRate, fireDistance, moveSpeed }

public class Upgrades : MonoBehaviour
{
    public int extraDamage = 0;
    public float projectileSpeedMultiplier = 1.0f;
    public float extraMovespeed = 0f;
    public float extraFireRate = 0f;
    public float extraFireDistance = 0f;

    public event Action<UpgradeType> OnUpgrade;

    public void UpgradStats(UpgradeType upgradeType, float amount)
    {
        switch (upgradeType)
        {
            case UpgradeType.damage:
                this.extraDamage += extraDamage;
                break;
            case UpgradeType.projectileSpeed:
                this.projectileSpeedMultiplier += projectileSpeedMultiplier;
                break;
            case UpgradeType.fireRate:
                this.extraFireRate += extraFireRate;
                break;
            case UpgradeType.fireDistance:
                this.extraFireDistance += extraFireDistance;
                break;
            case UpgradeType.moveSpeed:
                this.extraMovespeed += extraMovespeed;
                break;
            default:
                break;
        }
        OnUpgrade.Invoke(upgradeType);
    }
}
