using UnityEngine;



public class FallDistanceTracker : MonoBehaviour
{
    private bool isGrounded = false;
    private float beforeJumpY = 0;
    private float totalFallDistance = 0;

    // Update is called once per frame
    void Update()
    {
        
        // only tracking falling from last landed position (downward arc of a jump isn't always a fall)
        if (isGrounded)
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
    
    public void setIsGrounded(bool value)
    {
        isGrounded = value;
    }

    public void resetTotalFallDistance()
    {
        totalFallDistance = 0;
    }
}
