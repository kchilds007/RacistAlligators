using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    public InputAction JumpInput;
    public PlayerInput playerInput;
    private Rigidbody2D rigidbody2D;
    private float jumpPower;
    private bool jump;
    private bool holdingSpace;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        JumpInput = playerInput.actions["Jump"];
        jump = false;
        jumpPower = GameParameters.minJumpPower;
        holdingSpace = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (JumpInput.ReadValue<float>() > 0.5)
        {
            holdingSpace = true;
            jumpPower += GameParameters.variableJumpPower;
            if (jumpPower > GameParameters.maxJumpPower)
            {
                jumpPower = GameParameters.maxJumpPower;
            }
        }
        else
        {
            if (holdingSpace = true)
            {
                jump = true;
                holdingSpace = false;
            }
        }
        
    }

    private void FixedUpdate()
    {
        if (jump)
        {
            rigidbody2D.AddForceY(jumpPower, ForceMode2D.Impulse);
            jumpPower = GameParameters.minJumpPower;
            jump = false;
        }
    }
}
