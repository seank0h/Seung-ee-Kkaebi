using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public int hit;
    public GameObject hitEffectToSpawn;
    public GameObject handRotation;
    // Start is called before the first frame update
    void Start()
    {
        handRotation = GameObject.Find("RightHandAnchor");
        hit = vrClient.cl.getCatchEvent();
    }

    // Update is called once per frame
    void Update()
    {
        // this.gameObject.transform.rotation = this.gameObject.transform.parent.rotation;
        //gameObject.transform.eulerAngles = handRotation.transform.eulerAngles;
    }

    void OnCollisionEnter(Collision co){
        
        if (co.gameObject.tag == "Dokkaebi"){
             hit = vrClient.cl.getCatchEvent();
            Debug.Log("***BAT *** COLLISION WITH DOKKAEBI");
            if (hit == 1)
                hit = 0;
            else
                hit = 1;
            co.gameObject.GetComponent<BasicGhostBehavior>().HitbyBat();
            Instantiate(hitEffectToSpawn, co.transform.position, Quaternion.identity);
            vrClient.cl.setCatchEvent(hit);
        }
        if(co.gameObject.tag == "Environment"){
            Debug.Log("***BAT *** COLLISION WITH ENVIRONMENT");
        }
        
    }
}
