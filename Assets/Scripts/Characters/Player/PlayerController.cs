using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerMovement movement;
    [SerializeField] PlayerShooting shoot;
    [SerializeField] TransformReferenceSO playerTransformRef;

    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
        movement.playerControls = playerControls;
        shoot.playerControls = playerControls;
        playerTransformRef.Value = this.transform;
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
