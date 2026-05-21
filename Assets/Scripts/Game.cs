using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public CanvasGroup StartMenuCanvasGroup;
    public CanvasGroup StatsCanvasGroup;
    public GameObject StatScreen;
    public GameObject WinScreen;

    public CanvasGroup WinCanvasGroup;
    private bool hasGameStarted = false;

    private bool gameWon = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 0f; // freeze game

        StatScreen.SetActive(false);
        WinScreen.SetActive(false);

        CanvasGroupDisplayer.Show(StartMenuCanvasGroup);
        CanvasGroupDisplayer.Hide(StatsCanvasGroup);
        CanvasGroupDisplayer.Hide(WinCanvasGroup);
    }

    // Update is called once per frame
    public void OnStartButtonClick()
    {
        Time.timeScale = 1f; // unfreeze game

        StatScreen.SetActive(true);
        CanvasGroupDisplayer.Show(StatsCanvasGroup);
        CanvasGroupDisplayer.Hide(StartMenuCanvasGroup);
        hasGameStarted = true;
    }
    public void OnPlayAgainButtonClick()
    {
        Time.timeScale = 1f; 
        ScoreKeeper.ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        
        if (gameWon && (ScoreKeeper.GetScore() >= GameParameters.MinScoreGoal))
        {
            Time.timeScale = 0f; // freeze game

            WinScreen.SetActive(true);
            CanvasGroupDisplayer.Show(WinCanvasGroup);
            StatScreen.SetActive(false);
        }
    }

    public void setGameWon(bool set)
    {
        gameWon = set;
    }
}
