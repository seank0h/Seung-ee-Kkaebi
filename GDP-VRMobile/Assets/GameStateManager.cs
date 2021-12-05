using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    public float curseProgress;
    public int dokkaebiLives;
    public float gameTime;
    public bool winLose;
    public bool playing;
    // Start is called before the first frame update
    void Start()
    {
        playing = true;
        timeBall.tb.startGame();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(mobile2vr.mobileToVRCl.GameOver())
        {
            Debug.Log("Game Over");
        }

    }
}
