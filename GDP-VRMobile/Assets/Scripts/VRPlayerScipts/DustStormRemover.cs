using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustStormRemover : MonoBehaviour
{
    public static DustStormRemover dsr;
    private GameObject Removal, originCol;
    private GameObject removerOrigin;
    private GameObject[] removers;
    private Renderer[] rend;
    public int index;
    public bool isTouching = false;
    public bool trigger;
    private Collider collider;

    void Start(){
        if(dsr && dsr != this)
            Destroy(this);
        else
            dsr = this;
        
        index =0;
        initObj();

        rend = new Renderer[4];
        Removal = GameObject.Find("DustStormRemoval");
        originCol = GameObject.Find("OriginCol");
    }

    void Update(){
        if(trigger && VRDustParticleEffect.VRdpe.effectOn){
            touchEvent(collider);
        }
        /*
        // Alpha lerping to visible
        for(int i = 0; i < 5; i++){
            originCol = GameObject.Find("OriginCol");
            if(isTouching && index == i){
                float percent = GetPercentageAlong(VRDustParticleEffect.VRdpe.pos[i], removers[i].transform.position, originCol.transform.position);
                if(i == 4){
                    return;
                }else{
                    rend[i+2] = Removal.transform.GetChild(i+2).GetComponent<Renderer>();
                    rend[i+2].material.color = Color.Lerp(Color.clear, Color.cyan, percent);
                }
            }
        }
        */
    }

    public void setTrigger(bool status, Collider col){
        trigger = status;
        collider = col;
    }

    public void disableTrigger(bool status){
        trigger = status;
    }

    private void touchEvent(Collider other) {       
        for(int i = 0; i < 3; i++) {
            if(other.gameObject.name == "RemoverOrigin" && index == i){
                initObj();
                Debug.Log("INDEX : " + index);
                if (index == 0){
                    removers[0].transform.GetChild(1).gameObject.SetActive(true);
                    removers[0].transform.GetChild(2).gameObject.SetActive(true);
                }
                removerOrigin.transform.position = Vector3.Lerp(removerOrigin.transform.position, removers[i].transform.position, Time.deltaTime * 2);
                isTouching = true;
            }
        }
    }

    public static float GetPercentageAlong(Vector3 start, Vector3 end, Vector3 hand){
        var start2end = end - start;
        var start2hand = hand - start;
        return Vector3.Dot(start2hand, start2end) / start2end.sqrMagnitude;
    }

    private void initObj(){
        removers = new GameObject[3];
        removers[0] = GameObject.Find("Remover_1");
        removers[1] = GameObject.Find("Remover_2");
        removers[2] = GameObject.Find("RemoverFinal");
        removerOrigin = GameObject.Find("RemoverOrigin");
    }

    // Alpha lerping to visible - NOT USED!! 
    /*
    public IEnumerator AlphaLerp(int j, float percent){
        float currentTime = 0;
        rend[j] = Removal.transform.GetChild(j).GetComponent<Renderer>(); 
        //Debug.Log("PERCENT : " + percent);

        while(currentTime < 1){
            rend[j].material.color = Color.Lerp(Color.clear, Color.red, currentTime);
            yield return null;
            currentTime += Time.deltaTime;
        }
    }*/

}
