using UnityEngine;

public class Game : MonoBehaviour
{
    public CanvasGroup StartMenuCanvasGroup;
    public CanvasGroup StatsCanvasGroup;
    public GameObject StatScreen;
    public GameObject WinScreen;

    public CanvasGroup WinCanvasGroup;
    private bool hasGameStarted = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StatScreen.SetActive(false);
        CanvasGroupDisplayer.Show(StartMenuCanvasGroup);
        CanvasGroupDisplayer.Hide(StatsCanvasGroup);
        CanvasGroupDisplayer.Hide(WinCanvasGroup);
    }

    // Update is called once per frame
    public void OnStartButtonClick()
    {
        StatScreen.SetActive(true);
        CanvasGroupDisplayer.Show(StatsCanvasGroup);
        CanvasGroupDisplayer.Hide(StartMenuCanvasGroup);
        hasGameStarted = true;
    }
}
