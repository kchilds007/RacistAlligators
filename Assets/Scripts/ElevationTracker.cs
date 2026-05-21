using UnityEngine;

public class ElevationTracker : MonoBehaviour
{
    private float highestPointReached = 0;
    
    private float lastPositionY;
    private float totalElevationClimbed = 0;
    private float startingY = -997.03f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        reset();
    }
    
    

    // Update is called once per frame
    void Update()
    {
        float relativeY = transform.position.y - startingY;
        if (relativeY > highestPointReached)
        {
            highestPointReached = relativeY;
        }

        if (transform.position.y > lastPositionY)
        {
            totalElevationClimbed += transform.position.y - lastPositionY;
            
        }
        lastPositionY = transform.position.y;
        
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
        return transform.position.y - startingY;
    }

    private void reset()
    {
        startingY = -997.03f;
        highestPointReached = 0;
        totalElevationClimbed = 0;
        lastPositionY = transform.position.y;
    }
    
    
    
}
