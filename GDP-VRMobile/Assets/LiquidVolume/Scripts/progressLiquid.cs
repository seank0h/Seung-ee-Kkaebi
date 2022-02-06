using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressLiquid : MonoBehaviour{
    // public GameObject[] flask = new GameObject[4];

    public Texture[] sprites = new Texture[5];
    public RawImage[] objs = new RawImage[4];

    [SerializeField]
    [Range(0, 100)]
    public float startVal;

    private float level;   // % 비율로
    private float prevLevel = -1;

    // Start is called before the first frame update
    void Start(){
        level = startVal;
    }

    // Update is called once per frame
    void Update(){
        if(prevLevel != level){
            Debug.Log(level);
            prevLevel = level;
            updateGauge(level);
        }
    }

    public void updateGauge(float level)
    {
        int fulls = (int)level/25;
        int detail = (int)level % 25;
        for (int i=0;i<fulls;i++)
        {
            objs[i].texture = sprites[0];
        }

        for (int i=3;i>=fulls+1;i--)
        {
            objs[i].texture = sprites[4];
        }
        if (fulls != 4)
        {
            if (detail == 0)
                objs[fulls].texture = sprites[4];
            else if (detail == 25)
                objs[fulls].texture = sprites[0];
            else if (detail > 0 && detail <= 8)
                objs[fulls].texture = sprites[3];
            else if (detail > 8 && detail <= 17)
                objs[fulls].texture = sprites[2];
            else
                objs[fulls].texture = sprites[1];
        }
        
    }

    /*public void updateLiauid(float liqLevel){
        float totalLevel = liqLevel * 4;
        float max = (int)totalLevel / 100;
        float rest = totalLevel % 100;

       // Debug.Log(max + " // " + rest);

        for (int i = 0; i < flask.Length; i++){
            if(max > i){
                //Debug.Log(i + "is Max");
                flask[i].GetComponent<LiquidVolumeFX.LiquidVolume>()._level = 1;
                flask[i].GetComponent<LiquidVolumeFX.LiquidVolume>().UpdateMaterialProperties();
            }else if(max == i){
                //Debug.Log(i + "is rest " + (float)rest/100);
                flask[i].GetComponent<LiquidVolumeFX.LiquidVolume>()._level = (float)rest/100;
                flask[i].GetComponent<LiquidVolumeFX.LiquidVolume>().UpdateMaterialProperties();
            }else{
               // Debug.Log(i + "is" + 0);
                flask[i].GetComponent<LiquidVolumeFX.LiquidVolume>()._level = 0;
                flask[i].GetComponent<LiquidVolumeFX.LiquidVolume>().UpdateMaterialProperties();
            }
        }
    }*/

    public void setLevel(int level){
        this.level = level;
    }

    public void increaseLevel(int level)
    {
        this.level += level;
    }

    public void decreaseLevel(int level)
    {
        this.level -= level;
    }

    public float getLevel()
    {
        return level;
    }
}
