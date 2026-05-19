using UnityEngine;

public class LegCollisions : MonoBehaviour
{
    
    public BoxCollider2D GroundCollider;
    public LayerMask GroundLayer;
    public LayerMask MudLayer;
    public LayerMask IceLayer;
    public LayerMask EnemyLayer;
    
    private Rigidbody2D rigidBody;
    private Player player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
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