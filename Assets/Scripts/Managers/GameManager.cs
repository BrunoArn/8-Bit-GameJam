using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private MapManager mapManager;
    [SerializeField] private GameObject starterMap;
    [SerializeField] private Vector3 gameStartPosition;
    [SerializeField] private GameObject healthUI;

    [SerializeField] private IntReference enemiesKC;
    [SerializeField] private GameEvent playerDeath;

    private bool isPLayerDead = false;

    private void Start()
    {
        mapManager = GetComponent<MapManager>();
        enemiesKC.Value = 0;
        //HandleGameOver(player);
    }

    void OnEnable()
    {
        player.GetComponent<Health>().onDeath += GameOver;
    }

    void OnDisable()
    {
        player.GetComponent<Health>().onDeath -= GameOver;
    }

    private void GameOver(GameObject player)
    {
        playerDeath.Raise();
        player.GetComponent<PlayerController>().enabled = false;
    }

    public void RestartMap()
    {
        mapManager.SpawnAnyMap(starterMap);
        isPLayerDead = true;
    }

    public void RestartPLayer()
    {
        if (isPLayerDead)
        {
            enemiesKC.Value = 0;

            player.GetComponent<Upgrades>().UpgradeReset();
            player.GetComponent<FlowerExperience>().ResetLevel();
            player.GetComponent<Health>().currentHealth = player.GetComponent<Health>().maxHealth;
            player.transform.position = gameStartPosition;
            player.GetComponent<PlayerController>().enabled = true;

            healthUI.GetComponent<PlayerHealthUi>().BuildHearts();

            isPLayerDead = false;
        }
    }
}
