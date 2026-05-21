using UnityEngine;

public class WinCollectible : MonoBehaviour
{
    public Game Game;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            if (ScoreKeeper.GetScore() >= GameParameters.MinScoreGoal)
            {
                Game.setGameWon(true);
                Destroy(gameObject);
            }
            else
            {
                spriteRenderer.color = Color.red; // turn red
            }
        }
    }
    void OnTriggerExit2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            spriteRenderer.color = originalColor; // restore when player leaves
        }
    }

}