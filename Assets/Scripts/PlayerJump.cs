using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    public Sprite[] sprites;
    public InputAction JumpInput;
    public PlayerInput playerInput;
    private Player player;
    private Rigidbody2D rigidbody2D;
    private float jumpPower;
    private bool jump;
    private bool holdingSpace;
    private SpriteRenderer spriteRenderer;

    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        player = GetComponent<Player>();
        JumpInput = playerInput.actions["Jump"];
        jump = false;
        jumpPower = GameParameters.minJumpPower;
        holdingSpace = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator =  GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void FixedUpdate()
    {
        if (GameParameters.isJumping)
        {
            return;
        }
        
        if (JumpInput.ReadValue<float>() > 0.5)
        {
            animator.enabled = false;
            spriteRenderer.sprite =  sprites[((int) (jumpPower)/2)];
            holdingSpace = true;
            jumpPower += GameParameters.variableJumpPower;
            if (jumpPower > GameParameters.maxJumpPower)
            {
                jumpPower = GameParameters.maxJumpPower;
            }
        }
        else
        {
            if (holdingSpace == true)
            {
                jump = true;
                holdingSpace = false;
            }
        }
        if (jump)
        {
            if (jumpPower > 2.0f)
            {
                spriteRenderer.sprite = sprites[6];
            }
            else
            {
                spriteRenderer.sprite = sprites[5];
                animator.enabled = true;
            }
            rigidbody2D.AddForceY(jumpPower, ForceMode2D.Impulse);
            if (!player.facingLeft())
            {
                rigidbody2D.AddForceX((jumpPower / 3) * -1, ForceMode2D.Impulse);
            }
            else
            {
                rigidbody2D.AddForceX((jumpPower / 3), ForceMode2D.Impulse);
            }
            
            jumpPower = GameParameters.minJumpPower;
            jump = false;
            
        }
    }
}
