using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isFacingLeft = false;
    private PlayerMovement playerMovement; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>(); 
    }

    // Update is called once per frame
    void Update()
    {
        FlipSprite(playerMovement.movement);
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
}
