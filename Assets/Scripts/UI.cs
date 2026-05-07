using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TMP_Text scoreText;
    
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
}
