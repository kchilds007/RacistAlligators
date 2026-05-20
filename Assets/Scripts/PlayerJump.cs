using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    public JumpCountTracker jumpCountTracker;
    
    public Sprite[] sprites;
    public InputAction JumpInput;
    public PlayerInput playerInput;
    private Player player;
    private Rigidbody2D rigidbody2D;
    private float jumpPower;
    private bool jump;
    private bool holdingSpace;
    private SpriteRenderer spriteRenderer;
    private bool isOnStickyGround = false;
    private LegCollisions LegCollisions;

    private Animator animator;
    private float originalMaxJumpPower;
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
        originalMaxJumpPower = GameParameters.maxJumpPower;
        LegCollisions =  GetComponent<LegCollisions>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
        if (LegCollisions.IsGrounded() == false)
        {
            return;
        }
        
        if (JumpInput.ReadValue<float>() > 0.5)
        {
            player.ChangeState(PlayerState.Jumping);
            animator.enabled = false;
            spriteRenderer.sprite =  sprites[((int) ((jumpPower)/7.5f))];
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
            jumpCountTracker.UpdateTotalJumpCount();
            if (jumpPower > 2.0f)
            {
                spriteRenderer.sprite = sprites[6];
            }
            else
            {
                spriteRenderer.sprite = sprites[5];
                animator.enabled = true;
            }

            jumpPower = jumpPower * 2;
            
            //rigidbody2D.AddForceY(, ForceMode2D.Impulse);
            if (!player.facingLeft())
            {
                rigidbody2D.AddForce(new Vector2((jumpPower/3) * -1.0f, jumpPower), ForceMode2D.Impulse);
            }
            else
            {
                rigidbody2D.AddForce(new Vector2((float)(jumpPower/3), jumpPower), ForceMode2D.Impulse);
            }
            
            
            jumpPower = GameParameters.minJumpPower;
            jump = false;
            
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("StickyGround"))
        {
            print("On sticky ground");
            isOnStickyGround = true;
            GameParameters.maxJumpPower = originalMaxJumpPower / 2f;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("StickyGround"))
        {
            isOnStickyGround = false;
            GameParameters.maxJumpPower = originalMaxJumpPower;
        }
    }
}
