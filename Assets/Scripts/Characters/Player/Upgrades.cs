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
                Debug.Log("entrei");
                this.extraDamage += (int)amount; 
                break;
            case UpgradeType.projectileSpeed:
                this.projectileSpeedMultiplier += amount;
                break;
            case UpgradeType.fireRate:
                this.extraFireRate += amount;
                break;
            case UpgradeType.fireDistance:
                this.extraFireDistance += amount;
                break;
            case UpgradeType.moveSpeed:
                this.extraMovespeed += amount;
                break;
            default:
                break;
        }
        OnUpgrade.Invoke(upgradeType);
    }

    public void UpgradeReset()
    {
        extraDamage = 0;
        projectileSpeedMultiplier = 1.0f;
        extraMovespeed = 0f;
        extraFireRate = 0f;
        extraFireDistance = 0f;
    }
}
