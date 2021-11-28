using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustStormRemoverCollision : MonoBehaviour
{
    public static DustStormRemoverCollision dsrc;

    private GameObject removerOrigin, remover1, remover2, remover3, remover4, removerFinal;

    
    void Start()
    {
        removerOrigin = GameObject.Find("RemoverOrigin");
        remover1 = GameObject.Find("Remover_1");
        remover2 = GameObject.Find("Remover_2");
        remover3 = GameObject.Find("Remover_3");
        remover4 = GameObject.Find("Remover_4");
        removerFinal = GameObject.Find("RemoverFinal");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "Col1"){
            remover1.SetActive(false);
            DustStormRemover.dustStormRemover.index = 1;

        }
        if(other.gameObject.name == "Col2"){
            remover2.SetActive(false);
            DustStormRemover.dustStormRemover.index = 2;

        }
        if(other.gameObject.name == "Col3"){
            remover3.SetActive(false);
            DustStormRemover.dustStormRemover.index = 3;

        }
        if(other.gameObject.name == "Col4"){
            remover4.SetActive(false);
            DustStormRemover.dustStormRemover.index = 4;

        }
        if(other.gameObject.name == "FinalCol"){
            removerOrigin.SetActive(false);
            removerFinal.SetActive(false);
            DustStormRemover.dustStormRemover.index = 0;
        }
    }
    /*
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "Col1"){
            Debug.Log("ORIGIN AND COL1 COLLIDED!!!");
        }    
    }*/
}
