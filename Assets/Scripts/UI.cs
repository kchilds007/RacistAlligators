using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TMP_Text scoreText;

    public TMP_Text jumpText;
    
    public TMP_Text totalFallDistanceText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void SetJumpText(int jumps)
    {
        jumpText.text = "Total Jumps: " + jumps;
    }

    public void SetTotalFallDistanceText(float totalFallDistance)
    {
        totalFallDistanceText.text = "Total Fall Distance: " + totalFallDistance;
    }
}
