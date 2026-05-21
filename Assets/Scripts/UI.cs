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
        totalJumpText.text = "Total Jumps: " + jumpCountTracker.getTotalJumpCount();
        totalFallDistanceText.text = "Total Fall Distance: " + fallDistanceTracker.getTotalFallDistance();
        currentElevationText.text = "Current Elevation: " + elevationTracker.getCurrentElevation();
        totalElevationClimbedText.text = "Total Elevation: " + elevationTracker.getTotalElevationClimbed();
        highestElevationText.text = "Highest Elevation: " + elevationTracker.getHighestPointReached();
    }

    // Update is called once per frame
    void Update()
    {
        
        // should probably implement some sort of observer pattern at this point, but this gets the job done
        totalJumpText.text = "Total Jumps: " + jumpCountTracker.getTotalJumpCount();
        totalFallDistanceText.text = "Total Fall Distance: " + fallDistanceTracker.getTotalFallDistance().ToString("F2");
        currentElevationText.text = "Current Elevation: " + elevationTracker.getCurrentElevation().ToString("F2");
        totalElevationClimbedText.text = "Total Elevation: " + elevationTracker.getTotalElevationClimbed().ToString("F2");
        highestElevationText.text = "Highest Elevation: " + elevationTracker.getHighestPointReached().ToString("F2");
    }
    public void SetScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }
    
}
