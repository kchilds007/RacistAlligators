using UnityEngine;

public class PlayerLand : MonoBehaviour
{
    public LegCollisions LegCollision;
    private bool wasNotGrounded;
    private Animator animator;
    private Player player;

    public Sounds Sounds;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
        wasNotGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!LegCollision.IsGrounded())
        {
            wasNotGrounded = true;
        }

        if (wasNotGrounded && LegCollision.IsGrounded())
        {
            Sounds.PlayLandClip();
            animator.enabled = true;
            player.ChangeState(PlayerState.Idle);
            wasNotGrounded = false;
        }
    }
}
