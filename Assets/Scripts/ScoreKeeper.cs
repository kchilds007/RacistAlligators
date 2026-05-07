using System;
using UnityEngine;

public static class ScoreKeeper
{
    public static int score = 0;
    
    public static void AddPoint()
    {
        score++;
    }
    
    public static void ResetScore()
    {
        score = 0;
    }
    
    public static int GetScore()
    {
        return score;
    }
}
