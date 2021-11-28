using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustStormRemover : MonoBehaviour
{
    public static DustStormRemover dustStormRemover;
    private GameObject Removal;
    private GameObject removerOrigin, remover1, remover2, remover3, remover4, removerFinal;

    public int index;

    void Start()
    {
         if(dustStormRemover && dustStormRemover != this)
            Destroy(this);
        else
            dustStormRemover = this;
        index =0;
        removerOrigin = GameObject.Find("RemoverOrigin");
        remover1 = GameObject.Find("Remover_1");
        remover2 = GameObject.Find("Remover_2");
        remover3 = GameObject.Find("Remover_3");
        remover4 = GameObject.Find("Remover_4");
        removerFinal = GameObject.Find("RemoverFinal");

    }

    private void OnTriggerStay(Collider other) {
        if(other.gameObject.name == "RemoverOrigin" && index ==0){                    
            removerOrigin.transform.position = Vector3.Lerp(removerOrigin.transform.position, remover1.transform.position, Time.deltaTime * 2);
           
        }
        if(other.gameObject.name == "RemoverOrigin" && index == 1){
            Debug.Log("Going ti remover2");
            removerOrigin.transform.position = Vector3.Lerp(removerOrigin.transform.position, remover2.transform.position, Time.deltaTime * 2);
            
        }
        if(other.gameObject.name == "RemoverOrigin" && index == 2){
            removerOrigin.transform.position = Vector3.Lerp(removerOrigin.transform.position, remover3.transform.position, Time.deltaTime * 2);
            
        }
        if(other.gameObject.name == "RemoverOrigin" && index == 3){
            removerOrigin.transform.position = Vector3.Lerp(removerOrigin.transform.position, remover4.transform.position, Time.deltaTime * 2);
            
        }
        if(other.gameObject.name == "RemoverOrigin" && index == 4){
            removerOrigin.transform.position = Vector3.Lerp(removerOrigin.transform.position, removerFinal.transform.position, Time.deltaTime * 2);
            
        } 
            /*
            if(removerOrigin.transform.position == remover1.transform.position){
                Debug.Log("EQUAL TRANSFORM@@@@");
                remover1.SetActive(false);
                removerOrigin.transform.position = Vector3.Lerp(remover1.transform.position, remover2.transform.position, Time.deltaTime * 2);
            }
            if(removerOrigin.transform.position == remover2.transform.position){
                remover2.SetActive(false);
                removerOrigin.transform.position = Vector3.Lerp(remover2.transform.position, remover3.transform.position, Time.deltaTime * 2);
            }
            if(removerOrigin.transform.position == remover3.transform.position){
                remover3.SetActive(false);
                removerOrigin.transform.position = Vector3.Lerp(remover3.transform.position, remover4.transform.position, Time.deltaTime * 2);
            }
            if(removerOrigin.transform.position == remover4.transform.position){
                remover4.SetActive(false);
                removerOrigin.transform.position = Vector3.Lerp(remover4.transform.position, removerFinal.transform.position, Time.deltaTime * 2);
            }
            */

            //removerOrigin.transform.position = Vector3.Lerp(remover1.transform.position, remover2.transform.position, Time.deltaTime * 2);
            //removerOrigin.transform.position = Vector3.Lerp(remover2.transform.position, remover3.transform.position, Time.deltaTime * 2);
            //removerOrigin.transform.position = Vector3.Lerp(remover3.transform.position, remover4.transform.position, Time.deltaTime * 2);
            //removerOrigin.transform.position = Vector3.Lerp(remover4.transform.position, removerFinal.transform.position, Time.deltaTime * 2);
            
            /*
            remover1_y = Random.Range(remover1_y + 0.3f, remover1_y - 0.3f);
            //Debug.Log("remover1_y : " + remover1_y);
            remover2_y = Random.Range(remover2_y + 0.03f, remover2_y - 0.03f);
            //Debug.Log("remover2_y : " + remover2_y);
            remover3_y = Random.Range(remover3_y + 0.03f, remover3_y - 0.03f);
            //Debug.Log("remover3_y : " + remover3_y);
            remover4_y = Random.Range(remover4_y + 0.03f, remover4_y - 0.03f);
            //Debug.Log("remover4_y : " + remover4_y);
            */
            //Removal.SetActive(true);

        
    }
}
