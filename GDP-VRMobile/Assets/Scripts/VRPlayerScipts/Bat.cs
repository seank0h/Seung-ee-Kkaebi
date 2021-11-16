using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision co){
        if(co.gameObject.tag == "Dokkaebi"){
            Debug.Log("***BAT *** COLLISION WITH DOKKAEBI");
        }
        if(co.gameObject.tag == "Environment"){
            Debug.Log("***BAT *** COLLISION WITH ENVIRONMENT");
        }
    }
}
