using UnityEngine;



public class FallDistanceTracker : MonoBehaviour
{
    private float beforeJumpY;
    private float totalFallDistance;
    private float lastFallDistance;

    void Start()
    {
        reset();
    }

    // Update is called once per frame
    void Update()
    {
        
        // only tracking falling from last landed position (downward arc of a jump isn't always a fall)
        // player.getState() != PlayerState.Falling
        if (GameParameters.isJumping)
        {
            beforeJumpY = transform.position.y;
        }
        else
        {
            if (transform.position.y < beforeJumpY)
            {
                totalFallDistance += (beforeJumpY - transform.position.y);
            }
        }
        
    }
    
    public float getTotalFallDistance()
    {
        return totalFallDistance;
    }
    
    private void reset()
    {
        totalFallDistance = 0;
        beforeJumpY = transform.position.y;
        totalFallDistance = 0;
    }
}
