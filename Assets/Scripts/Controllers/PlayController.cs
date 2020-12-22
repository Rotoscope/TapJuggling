using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayController : MonoBehaviour
{
    public GameObject itemMount;
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject floor;
    public Text scoreText;

    private static PlayController instance;

    public static PlayController Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            ScoreManager.Instance.onScoreIncrement += UpdateScoreText;
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    internal void UpdateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }
}
