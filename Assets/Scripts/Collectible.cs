using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Collectible : MonoBehaviour
{
    public UI Ui;
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            ScoreKeeper.AddPoint();
            Ui.SetScoreText(ScoreKeeper.GetScore());
            Destroy(gameObject);
        }
    }
}
