using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameStateManager : MonoBehaviour
{
    public float curseProgress;
    public int dokkaebiLives;
    public bool winLose;
    public bool playing;
    public GameObject BGMManagerEntity;
    BGM bgmManager;

    public GameObject gaugeBall;
    MeshRenderer gaugeBallRenderer;

    public GameObject gameWin;
    public GameObject gameLose;
    public GameObject gameConditionCanvas;

    // Start is called before the first frame update
    void Start()
    {
        playing = true;
        bgmManager = BGMManagerEntity.GetComponent<BGM>();
        gaugeBallRenderer = gaugeBall.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(mobile2vr.mobileToVRCl.GameWin())
        {
            gaugeBallRenderer.enabled = false;
            gameConditionCanvas.SetActive(true);
            gameWin.SetActive(true);
            Invoke("ReturnToMainMenu", 4.0f);
        }
        
        if(mobile2vr.mobileToVRCl.GameLose())
        {

            gaugeBallRenderer.enabled = false;
            gameConditionCanvas.SetActive(true);
            gameLose.SetActive(true);
            Invoke("ReturnToMainMenu", 4.0f);
        }
        
    }

    void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenuVR");
    }
}
