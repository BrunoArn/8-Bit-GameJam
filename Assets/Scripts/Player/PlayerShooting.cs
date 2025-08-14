using System;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;

    [SerializeField] private Transform shootOrigin;
    [SerializeField] private float spawnDistance = 0.06f;

    private PlayerControls playerControls;
    private Vector2 lastAim = Vector2.right;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }
    void OnEnable()
    {
        playerControls.Enable();
        playerControls.Combat.Shoot.performed += OnShootPerformed;
    }
    void OnDisable()
    {
        playerControls.Combat.Shoot.performed -= OnShootPerformed;
        playerControls.Disable();
    }
    void Update()
    {

    }
    private void OnShootPerformed(InputAction.CallbackContext context)
    {
        Vector2 aim = context.ReadValue<Vector2>();
        lastAim = aim;

        if (Mathf.Abs(lastAim.x) > Mathf.Abs(lastAim.y))
            lastAim = new Vector2(Mathf.Sign(lastAim.x), 0f);
        else
            lastAim = new Vector2(0f, Mathf.Sign(lastAim.y));

        Vector3 spawnPos = shootOrigin.position + (Vector3)(lastAim.normalized * spawnDistance);
        Vector3 direction = (Vector3)lastAim.normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        var go = Instantiate(projectilePrefab, spawnPos, Quaternion.Euler(0,0, angle));
        var projectile = go.GetComponent<PlayerProjectile>();
        projectile.UpdateProjectileInfo(0, 1);

    }
}
