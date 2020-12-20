using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    public GameObject itemMount;
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject floor;

    private static PlayManager instance;

    public static PlayManager Instance { get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
