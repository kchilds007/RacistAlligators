using UnityEngine;



public class FallDistanceTracker : MonoBehaviour
{
    private float beforeJumpY;
    private float totalFallDistance;
    private float lastFallDistance;
    private Player player;

    void Start()
    {
        reset();
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // only tracking falling from last landed position (downward arc of a jump isn't always a fall)
        if (player.getState() == PlayerState.Jumping)
        {
            beforeJumpY = transform.position.y;
        }
        else if(player.getState() == PlayerState.Falling)
        {
            if (transform.position.y < beforeJumpY)
            {
                totalFallDistance += (beforeJumpY - transform.position.y);
            }
            beforeJumpY = transform.position.y; // reset for next jump

        }
        
    }
    
    public float getTotalFallDistance()
    {
        return totalFallDistance;
    }
    
    private void reset()
    {
        beforeJumpY = transform.position.y;
        totalFallDistance = 0;
    }
}
