using UnityEngine;

public class ElevationTracker : MonoBehaviour
{
    private float highestPointReached = 0;
    
    // private bool isGrounded;
    private float lastPositionY;
    private float totalElevationClimbed = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > highestPointReached)
        {
            highestPointReached = transform.position.y;
        }

        if (transform.position.y > lastPositionY)
        {
            totalElevationClimbed = transform.position.y - lastPositionY;
            lastPositionY = transform.position.y;
        }
        
    }

    public float getHighestPointReached()
    {
        return highestPointReached;
    }
    
    public float getTotalElevationClimbed()
    {
        return totalElevationClimbed;
    }

    public float getCurrentElevation()
    {
        return transform.position.y;
    }

    private void reset()
    {
        highestPointReached = 0;
        totalElevationClimbed = 0;
        lastPositionY = transform.position.y;
    }
    
}
