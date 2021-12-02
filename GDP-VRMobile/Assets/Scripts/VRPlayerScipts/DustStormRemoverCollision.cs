using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustStormRemoverCollision : MonoBehaviour
{
    public static DustStormRemoverCollision dsrc;
    private GameObject Removal;
    private GameObject removerOrigin, remover1, remover2, remover3, remover4, removerFinal;
    private Vector3 originalPos;

    void Start(){
        removerOrigin = GameObject.Find("RemoverOrigin");
        remover1 = GameObject.Find("Remover_1");
        remover2 = GameObject.Find("Remover_2");
        remover3 = GameObject.Find("Remover_3");
        remover4 = GameObject.Find("Remover_4");
        removerFinal = GameObject.Find("RemoverFinal");

        Removal = GameObject.Find("DustStormRemoval");
        originalPos = removerOrigin.transform.position;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "Col1"){
            remover1.GetComponent<Renderer>().material.color = Color.clear;
            remover1.SetActive(false);
            DustStormRemover.dsr.index = 1;

        }
        if(other.gameObject.name == "Col2"){
            remover2.GetComponent<Renderer>().material.color = Color.clear;
            remover2.SetActive(false);
            DustStormRemover.dsr.index = 2;

        }
        if(other.gameObject.name == "Col3"){
            remover3.GetComponent<Renderer>().material.color = Color.clear;
            remover3.SetActive(false);
            DustStormRemover.dsr.index = 3;

        }
        if(other.gameObject.name == "Col4"){
            remover4.GetComponent<Renderer>().material.color = Color.clear;
            remover4.SetActive(false);
            DustStormRemover.dsr.index = 4;

        }
        if(other.gameObject.name == "FinalCol"){
            removerOrigin.GetComponent<Renderer>().material.color = Color.clear;
            removerFinal.GetComponent<Renderer>().material.color = Color.clear;
            removerOrigin.SetActive(false);
            removerFinal.SetActive(false);
            
            DustStormRemover.dsr.index = 0;
            removerOrigin.transform.position = originalPos;
            DustStormRemover.dsr.trigger = false;
            DustStormRemover.dsr.isTouching = false;
        }
    }
}
