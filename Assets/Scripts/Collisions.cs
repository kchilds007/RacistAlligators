using UnityEngine;

public class Collisions : MonoBehaviour
{
    private Player player;
    private PlayerMovement playerMovement; 
    public Rigidbody2D rigidbody2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Player>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GameParameters.isJumping = false;
        } else if (collision.gameObject.CompareTag("Wall"))
        {
            rigidbody2D.linearVelocityX *= -1;
        }
    }
}
