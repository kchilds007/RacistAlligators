using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public InputAction MoveInput;
    public PlayerInput playerInput;
    public Animator Animator;
    private float acceleration = GameParameters.acceleration;
    private float decceleration = GameParameters.decceleration;
    private float velPower = GameParameters.velPower;
    public float baseSpeed;
    private float currentSpeed;
    public Vector2 movement;

    private Vector2 moveDir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpeed = baseSpeed;
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        MoveInput = playerInput.actions["Move"];
        Animator =  GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = MoveInput.ReadValue<Vector2>();

    }
    void FixedUpdate()
    {
        if (GameParameters.isJumping)
        {
            return;
        }
        float targetSpeed = movement.x * currentSpeed;
        float speedDiff = targetSpeed - GetComponent<Rigidbody2D>().linearVelocity.x;
        
        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
        float finalMove = Mathf.Pow(Mathf.Abs(speedDiff), velPower) * accelRate * Mathf.Sign(speedDiff);
        GetComponent<Rigidbody2D>().AddForce(finalMove * Vector2.right, ForceMode2D.Force);
        Animate();
    }

    private void Animate()
    {
        Animator.SetFloat("Horizontal", Mathf.Abs(GetComponent<Rigidbody2D>().linearVelocity.x));
    }
}
