using UnityEngine;



public class FallDistanceTracker : MonoBehaviour
{
    public Player player;
    
    private float beforeJumpY = 0;
    private float totalFallDistance = 0;
    private float lastFallDistance = 0;

    // Update is called once per frame
    void Update()
    {
        
        // only tracking falling from last landed position (downward arc of a jump isn't always a fall)
        if (player.getState() != PlayerState.Falling)
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
    
    public void resetTotalFallDistance()
    {
        totalFallDistance = 0;
    }
}
