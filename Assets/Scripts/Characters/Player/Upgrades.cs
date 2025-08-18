using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public int extraDamage = 0;
    public float projectileSpeedMultiplier = 1.0f;
    public float extraMovespeed = 0f;
    public float extraFireRate = 0f;
    public float extraFireDistance = 0f;

    public void UpgradStats(int extraDamage, float projectileSpeedMultiplier, float extraMovespeed, float extraFireRate, float extraFireDistance)
    {
        this.extraDamage += extraDamage;
        this.projectileSpeedMultiplier += projectileSpeedMultiplier;
        this.extraMovespeed += extraMovespeed;
        this.extraFireRate += extraFireRate;
        this.extraFireDistance += extraFireDistance;
    }
}
