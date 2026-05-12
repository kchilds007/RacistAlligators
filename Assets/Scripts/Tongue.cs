using UnityEngine;
using UnityEngine.InputSystem;

public class Tongue : MonoBehaviour
{
    public Launcher Launcher;

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
        Launcher.Launch(aimDirection);
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