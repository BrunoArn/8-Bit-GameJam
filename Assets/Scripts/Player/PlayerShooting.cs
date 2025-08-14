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
    [SerializeField] private float fireRate = 0.5f;
    private float fireCooldown = 0f;

    public PlayerControls playerControls;
    private Vector2 lastAim = Vector2.right;
    private float projectileZAngle;
    private Vector3 spawnPos;

    void Update()
    {
        if (fireCooldown > 0f)
            fireCooldown -= Time.deltaTime;

        Vector2 inputValue = playerControls.Combat.Fire.ReadValue<Vector2>();

        if (inputValue != Vector2.zero && fireCooldown <= 0)
        {
            UpdateAim(inputValue);
            Shoot();
            fireCooldown = fireRate;
        }
    }
    private void UpdateAim(Vector2 inputValue)
    {
        lastAim = inputValue;

        if (Mathf.Abs(lastAim.x) > Mathf.Abs(lastAim.y))
            lastAim = new Vector2(Mathf.Sign(lastAim.x), 0f);
        else
            lastAim = new Vector2(0f, Mathf.Sign(lastAim.y));

        spawnPos = shootOrigin.position + (Vector3)(lastAim.normalized * spawnDistance);
        Vector3 direction = lastAim.normalized;
        projectileZAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

    private void Shoot()
    {
        var go = Instantiate(projectilePrefab, spawnPos, Quaternion.Euler(0, 0, projectileZAngle));
        var projectile = go.GetComponent<PlayerProjectile>();
        projectile.UpdateProjectileInfo(0, 1);

    }
}
