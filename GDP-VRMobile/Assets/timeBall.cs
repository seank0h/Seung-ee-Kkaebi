using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeBall : MonoBehaviour{
    public static timeBall tb;

    private Shader color;
    private float fill;

    public int gameTotalMin = 5;
    private float timer, fps = 90, colTime;
    public bool timerStart;

    // Start is called before the first frame update
    void Start(){
        timeBall.tb = this;
        fill = 0;
    }

    // Update is called once per frame
    void Update(){
        if(timerStart && fill < 1.0f){
            timer += Time.deltaTime;
            colTime = 100 * timer/fps;

            //0 ~ 60*gameTotalMin  -> 0 ~ 1
            fill = colTime / (60 * gameTotalMin);
            //Debug.Log(fill);
        }
        
        GetComponent<Renderer>().material.SetFloat("_Cutoff", fill);
    }


    public void startGame(){
        timerStart = true;
    }

    public bool isGameEnd(){
        if(fill >= 1){
            return true;
        }else{
            return false;
        }
    }
}
