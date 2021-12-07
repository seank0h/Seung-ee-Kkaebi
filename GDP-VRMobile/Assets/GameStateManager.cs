using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    public float curseProgress;
    public int dokkaebiLives;
    public bool winLose;
    public bool playing;
    public GameObject BGMManagerEntity;
    BGM bgmManager;

    public Text gameStateText;
    public GameObject gameConditionCanvas;
    public GameObject timeBallEntity;
    timeBall timeBall;
    // Start is called before the first frame update
    void Start()
    {
        playing = true;
        timeBall = timeBallEntity.GetComponent<timeBall>();
        bgmManager = BGMManagerEntity.GetComponent<BGM>();
        timeBall.startGame();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(mobile2vr.mobileToVRCl.GameOver())
        {
            gameStateText.text = "You Win Congratulations";
            gameConditionCanvas.SetActive(true);
        }
        
        if(timeBall.isGameEnd() || vrClient.cl.getLife()<=0)
        {
           
            gameStateText.text = "You Win Congratulations";
            gameConditionCanvas.SetActive(true);
            
        }
        if(gameObject.GetComponent<CurseVisualizer>().villagePranked)
        {
      
            gameStateText.text = "You Lose Boohoo";
            gameConditionCanvas.SetActive(true);
        }

        if(gameObject.GetComponent<CurseVisualizer>().villageHalfPranked)
        {
            //bgmManager.InEmergencyBGM();
        }
    }
}
