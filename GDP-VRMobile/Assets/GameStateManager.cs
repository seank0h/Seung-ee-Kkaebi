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
    public Slider curseProgressBar;
    public float FillSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        curseProgressBar.value = 0;
        curseProgressBar.maxValue = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("curseprogressbar val:" + curseProgressBar.value);
        if (curseProgressBar.value < curseProgress)
            curseProgressBar.value += FillSpeed * Time.deltaTime;

        
    }

    public void IncrementProgress(float newCurseProgress)
    {
        Debug.Log("Called IncrementProgress");
        curseProgress = curseProgressBar.value + newCurseProgress;
    }
}
