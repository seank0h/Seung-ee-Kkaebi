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

    // Start is called before the first frame update
    void Start()
    {
        playing = true;
        bgmManager = BGMManagerEntity.GetComponent<BGM>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(mobile2vr.mobileToVRCl.GameWin())
        {
            //gameStateText.text = "You Win";
            //gameConditionCanvas.SetActive(true);
        }
        
        if(mobile2vr.mobileToVRCl.GameLose())
        {
           
            gameStateText.text = "You Lose";
            gameConditionCanvas.SetActive(true);
            
        }
        
    }
}
