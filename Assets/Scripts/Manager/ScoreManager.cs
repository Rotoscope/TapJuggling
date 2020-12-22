using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager
{
    internal static ScoreManager instance;
    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ScoreManager();
            }
            return instance;
        }
    }

    public int Score { get; private set; } = 0;
    public System.Action<int> onScoreIncrement;

    public void IncrementScore()
    {
        onScoreIncrement?.Invoke(++Score);
    }

    public float GetTimeSurvived
    {
        get
        {
            return Time.timeSinceLevelLoad;
        }
    }
}
