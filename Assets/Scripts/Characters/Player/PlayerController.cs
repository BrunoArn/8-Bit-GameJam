using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerMovement movement;
    [SerializeField] PlayerShooting shoot;

    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
        movement.playerControls = playerControls;
        shoot.playerControls = playerControls;
    }

    void OnEnable()
    {
        playerControls.Enable();
        
    }
    void OnDisable()
    {
        playerControls.Disable();
    }
}
