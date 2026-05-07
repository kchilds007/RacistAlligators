using UnityEngine;

public class MobileMob : MonoBehaviour
{
    protected bool isFacingLeft = false;
    protected Vector2 movement;
    protected Rigidbody2D rigidbody2D;
    protected Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        FlipSprite(movement);
    }
    public void FlipSprite(Vector2 movement)
    {
        if (isFacingLeft && movement.x < 0f || !isFacingLeft && movement.x > 0f)
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
