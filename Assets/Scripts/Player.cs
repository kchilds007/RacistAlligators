using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isFacingLeft = false;
    private PlayerMovement playerMovement;
    private Rigidbody2D rigidbody2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>(); 
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        FlipSprite(rigidbody2D.linearVelocityX);
    }
    public void FlipSprite(float x)
    {
        if (isFacingLeft && x < 0f || !isFacingLeft && x > 0f)
        {
            isFacingLeft = !isFacingLeft;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    
    public bool facingLeft()
    {
        return isFacingLeft;
    }
}
