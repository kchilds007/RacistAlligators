using System.Collections;
using UnityEngine;

public class LegCollisions : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite fallingSprite;
    public Animator animator;

    private IEnumerator coroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.sprite =  fallingSprite;
        animator.enabled = false;
        GameParameters.isJumping = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.Play("Base Layer.Landing", 0, 0);
        animator.enabled = true;
        StartCoroutine(waitForLanding());
    }
    
    private IEnumerator waitForLanding()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);
        GameParameters.isJumping = false;
        
    }
    
}
