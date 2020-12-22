using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager
{
    internal static LifeManager instance;
    public static LifeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new LifeManager();
            }
            return instance;
        }
    }

    public int LifeCount { get; private set; } = GameConstants.INITIAL_LIFE_COUNT;

    public void DecrementLife()
    {
        LifeCount--;
        if (LifeCount <= 0)
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
