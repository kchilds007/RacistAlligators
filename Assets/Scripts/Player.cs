using UnityEngine;

public enum PlayerState
{
    Idle,
    Walking,
    Falling,
    Jumping
}

public class Player : MobileMob
{
    private PlayerState playerState;
    private PlayerMovement playerMovement; 
    public LegCollisions legCollisions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Start();
        playerMovement = GetComponent<PlayerMovement>(); 
    }

    // Update is called once per frame
    void Update()
    {
        movement = playerMovement.movement;
        if (!legCollisions.IsGrounded())
        {
            ChangeState(PlayerState.Falling);
        }
        base.Update();
    }

    public void ChangeState(PlayerState newState)
    {
        playerState = newState;
    }

    public PlayerState getState()
    {
        return playerState;
    }
    
}
