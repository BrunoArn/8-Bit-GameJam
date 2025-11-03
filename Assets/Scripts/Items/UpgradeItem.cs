using UnityEngine;

public class UpgradeItem : MonoBehaviour
{
    [SerializeField] private UpgradeType upgradeType;
    [SerializeField] private float value = 0f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Upgrades>(out Upgrades upgrades))
        {
            upgrades.UpgradStats(upgradeType, value);
        }
    }
}
