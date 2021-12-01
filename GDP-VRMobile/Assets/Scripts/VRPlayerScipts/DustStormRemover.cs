using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustStormRemover : MonoBehaviour
{
    public static DustStormRemover dsr;
    private GameObject Removal, originCol;
    private GameObject removerOrigin;
    private GameObject[] removers;
    private Renderer rendO;
    private Renderer[] rend;
    public int index;

    public bool trigger;
    private Collider collider;

    void Start(){
        if(dsr && dsr != this)
            Destroy(this);
        else
            dsr = this;
        
        index =0;
        initObj();

        rend = new Renderer[5];

        Removal = GameObject.Find("DustStormRemoval");
        originCol = GameObject.Find("OriginCol");
    }

    void Update(){
        if(trigger && VRDustParticleEffect.VRdpe.effectOn){
            touchEvent(collider);
        }
    }

    public void setTrigger(bool status, Collider col){
        trigger = status;
        collider = col;
    }

    public void disableTrigger(bool status){
        trigger = status;
    }

    private void touchEvent(Collider other) {       
        for(int i = 0; i < 5; i++) {
            if(other.gameObject.name == "RemoverOrigin" && index == i){
                initObj();
                Debug.Log("INDEX : " + index);

                removerOrigin.transform.position = Vector3.Lerp(removerOrigin.transform.position, removers[i].transform.position, Time.deltaTime * 2);
                float percent = GetPercentageAlong(removerOrigin.transform.position, removers[i].transform.position, originCol.transform.position);
                
                if(i == 4){
                    return;
                }else{
                    StartCoroutine(AlphaLerp(i + 1, percent));
                }
                
                
            }
        }
    }

    // Alpha lerping to visible
    public IEnumerator AlphaLerp(int j, float percent){

        float currentTime = 0;

        rend[j] = Removal.transform.GetChild(j).GetComponent<Renderer>();
       
        while(currentTime < 1){
            rend[j].material.color = Color.Lerp(Color.clear, Color.red, currentTime);
            yield return null;
            currentTime += Time.deltaTime;
        }

        
    }

    public static float GetPercentageAlong(Vector3 start, Vector3 end, Vector3 hand){
        var start2end = end - start;
        var start2hand = hand - start;
        return Vector3.Dot(start2hand, start2end) / start2end.sqrMagnitude;
    }

    private void initObj(){
        removers = new GameObject[5];
        removers[0] = GameObject.Find("Remover_1");
        removers[1] = GameObject.Find("Remover_2");
        removers[2] = GameObject.Find("Remover_3");
        removers[3] = GameObject.Find("Remover_4");
        removers[4] = GameObject.Find("RemoverFinal");
        removerOrigin = GameObject.Find("RemoverOrigin");
    }

}
