using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private IntReference enemiesKc;
    [SerializeField] private TextMeshProUGUI enemiesCountText;

    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameEvent resetGame;

    private PlayerControls controls;
    private bool isActive = false;

    private void Awake()
    {
        controls = new PlayerControls();
    }

    void OnEnable()
    {
        controls.UI.Enable();
        controls.UI.Restart.performed += ResetGame;
    }
    void OnDisable()
    {
        controls.UI.Disable();
        controls.UI.Restart.performed -= ResetGame;
    }

    private void ResetGame(InputAction.CallbackContext context)
    {
        if (isActive)
        {
            isActive = false;
            gameOverUI.gameObject.SetActive(false);
            resetGame.Raise();
        }
    }


    public void ShowGameOver()
    {
        gameOverUI.gameObject.SetActive(true);
        isActive = true;
        enemiesCountText.text = enemiesKc.Value.ToString();
    }
}
