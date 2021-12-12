using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class progressLiquid : MonoBehaviour{
    public GameObject[] flask = new GameObject[4];

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
            prevLevel = level;
            updateLiauid(level);
        }
    }

    public void updateLiauid(float liqLevel){
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
    }

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
