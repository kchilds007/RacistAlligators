using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Collectible : MonoBehaviour
{
    public UI Ui;
    public Sounds Sounds;
    
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            ScoreKeeper.AddPoint();
            Sounds.PlayCoinClip();
            Ui.SetScoreText(ScoreKeeper.GetScore());
            Destroy(gameObject);
        }
    }
}
