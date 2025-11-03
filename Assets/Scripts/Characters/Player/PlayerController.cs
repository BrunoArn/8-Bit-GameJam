using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player actions")]
    [SerializeField] PlayerMovement movement;
    [SerializeField] PlayerShooting shoot;
    [SerializeField] TransformReferenceSO playerTransformRef;

    private PlayerControls playerControls;
    
    [Header("Player animations")]
    private Animator myAnimator;
    [SerializeField] private Health health;

    private void Awake()
    {
        playerControls = new PlayerControls();
        movement.playerControls = playerControls;
        shoot.playerControls = playerControls;
        playerTransformRef.Value = this.transform;

        myAnimator = GetComponent<Animator>();
        health.onTakeDamage += HurtAnimation;
    }

    void OnEnable()
    {
        playerControls.Enable();

    }
    void OnDisable()
    {
        playerControls.Disable();
    }

    private void HurtAnimation()
    {
        myAnimator.SetTrigger("TakeDamage");
    }
}
