
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("PLayer status")]
    [SerializeField] private float moveSpeed = 1f;
    public PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Upgrades upgrade;

    private Animator myAnimator;
    private SpriteRenderer spriteRenderer;
    


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        upgrade = GetComponent<Upgrades>();
        myAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PlayerInput();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void PlayerInput()
    {
        movement = playerControls.Combat.Move.ReadValue<Vector2>();
        
        if (movement != Vector2.zero) { myAnimator.SetBool("isMoving", true); }
        else { myAnimator.SetBool("isMoving", false); }
        
        if (movement.x < 0) { spriteRenderer.flipX = true; }
        else if (movement.x > 0) { spriteRenderer.flipX = false; } 
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * ((moveSpeed + upgrade.extraMovespeed) * Time.deltaTime));
    }

}
