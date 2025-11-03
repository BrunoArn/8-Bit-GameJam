using TMPro;
using UnityEngine;

public class UpgradeUi : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Upgrades playerUpgrades;

    void OnEnable()
    {
        playerUpgrades.OnUpgrade += UpgradeFeedback;
    }
    void OnDisable()
    {
        playerUpgrades.OnUpgrade -= UpgradeFeedback;
    }

    private void UpgradeFeedback(UpgradeType upgradeType)
    {
        string text = "";

        switch (upgradeType)
        {
            case UpgradeType.damage:
                text = "Extra damage!";
                break;
            case UpgradeType.projectileSpeed:
                text = "Projectile speed increase!";
                break;
            case UpgradeType.fireRate:
                text = "Fire Rate increase!";
                break;
            case UpgradeType.fireDistance:
                text = "Extra fire distance!";
                break;
            case UpgradeType.moveSpeed:
                text = "Move speed increase!";
                break;
            default:
                break;
        }
        var slot = Instantiate(slotPrefab, this.transform);
        slot.GetComponent<UpgradeUISlot>().Initialize(text);
    }
}
