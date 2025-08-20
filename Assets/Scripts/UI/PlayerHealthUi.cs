using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUi : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Health playerHealth;
    [SerializeField] private GameObject heartPrefab;

    private readonly List<HeartContainerUi> containerList = new List<HeartContainerUi>();

    void Awake()
    {
        if (!playerHealth) Debug.Log("faltando player");
    }

    void OnEnable()
    {
        if (playerHealth)
        {
            playerHealth.onTakeDamage += UpdateUI;
            playerHealth.onRaiseMaxHealth += BuildHearts;
        }
    }

    void OnDisable()
    {
        if (playerHealth)
        {
            playerHealth.onTakeDamage -= UpdateUI;
            playerHealth.onRaiseMaxHealth -= BuildHearts;
        }
    }

    private void Start()
    {
        BuildHearts();
    }

    private void BuildHearts()
    {
        for (int i = 0; i < playerHealth.maxHealth; i++)
        {
            var slot = Instantiate(heartPrefab, this.transform);
            containerList.Add(slot.GetComponent<HeartContainerUi>());
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < playerHealth.maxHealth; i++)
        {
            if (i > playerHealth.currentHealth - 1)
            {
                containerList[i].HeartFill(false);
            }
            else
            {
                containerList[i].HeartFill(true);
            }
        }
    }
}
