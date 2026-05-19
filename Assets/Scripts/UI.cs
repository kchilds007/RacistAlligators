using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TMP_Text scoreText;

    public TMP_Text totalJumpText;
    
    public TMP_Text totalFallDistanceText;
    
    public TMP_Text highestElevationText;
    
    public TMP_Text totalElevationClimbedText;
    
    public TMP_Text currentElevationText;
    
    public FallDistanceTracker fallDistanceTracker;
    public ElevationTracker elevationTracker;
    public JumpCountTracker jumpCountTracker;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // should probably implement some sort of observer pattern at this point, but this gets the job done
        if (jumpCountTracker.getTotalJumpCount().ToString() != totalJumpText.text)
        {
            totalJumpText.text = "Total Jumps: " + jumpCountTracker.getTotalJumpCount();
        }

        if (elevationTracker.getHighestPointReached().ToString() != highestElevationText.text)
        {
            highestElevationText.text = "Highest Elevation: " + highestElevationText.text;
        }

        if (elevationTracker.getCurrentElevation().ToString() != currentElevationText.text)
        {
            currentElevationText.text = "Current Elevation: " + currentElevationText.text;
        }

        if (elevationTracker.getTotalElevationClimbed().ToString() != totalElevationClimbedText.text)
        {
            totalElevationClimbedText.text = "Total Elevation: " + totalElevationClimbedText.text;
        }

        if (fallDistanceTracker.getTotalFallDistance().ToString() != totalFallDistanceText.text)
        {
            totalFallDistanceText.text = "Total Fall Distance: " + totalFallDistanceText.text;
        }
        
    }
    public void SetScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }
}
