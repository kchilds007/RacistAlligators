using UnityEngine;

public class LegCollisions : MonoBehaviour
{
    
    private BoxCollider2D GroundCollider;
    public LayerMask GroundLayer;
    public LayerMask MudLayer;
    public LayerMask IceLayer;
    public LayerMask EnemyLayer;
    
    public Rigidbody2D rigidBody;
    public Player player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GroundCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsGrounded()
    {
        
        LayerMask landableLayers = GroundLayer | MudLayer | IceLayer;
        
        return Physics2D.OverlapBox(
            GroundCollider.bounds.center,   // centre of the box in world space
            GroundCollider.bounds.size,     // width and height of the box
            0f,                             // rotation of the box (0 = no rotation)
            landableLayers                  // only detect these layers
        );
    }

    public bool IsRising()
    {
        return rigidBody.linearVelocity.y > 0f;
    }

    public bool IsFalling()
    {
        return rigidBody.linearVelocity.y < 0f ;
    }
}