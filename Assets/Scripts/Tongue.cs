using UnityEngine;
using UnityEngine.InputSystem;

public class Tongue : MonoBehaviour
{
    public Launcher Launcher;
    public Transform PlayerLocation;
    public MobileMob player;

    private float attackCooldown = GameParameters.PlayerAttackCooldown;
    // Update is called once per frame
    void Update()
    {
        attackCooldown -= Time.deltaTime;

        if (attackCooldown > 0) 
        {
            return;
        }

        //if (Game.IsGameNotStarted())
        //{
        //  return;
        //}
        
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Launch();
            attackCooldown = GameParameters.PlayerAttackCooldown;
        }
        //if mouse clicked launch ball
        
    }

    private void Launch()
    {
        Vector2 aimDirection = GetAimDirection();
        LaunchInDirection(aimDirection);


    }

    private void LaunchInDirection(Vector2 aimDirection)
    {
        if (player.facingLeft())
        {
            if (aimDirection.x > 0)
            {
                Launcher.Launch(aimDirection, -1);
            }
            else
            {
                attackCooldown = 0;
            }
        }
        else
        {
            if (aimDirection.x < 0)
            {
                Launcher.Launch(aimDirection, 1);
            }
            else
            {
                attackCooldown = 0;
            }
        }
    }

    private Vector2 GetAimDirection()
    {
        Vector3 mouseWorld = GetMouseWorldPosition();
        return (mouseWorld - Launcher.ProjectileSpawnPoint.position).normalized;
    }
    private Vector3 GetMouseWorldPosition()
    {
        Vector2 mouseScreen = Mouse.current.position.ReadValue();
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);
        mouseWorld.z = 0f;
        return mouseWorld;
    }
}