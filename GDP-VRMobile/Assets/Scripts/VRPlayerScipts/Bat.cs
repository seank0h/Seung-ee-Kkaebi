using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public int hit;
    public GameObject hitEffectToSpawn;
    public GameObject handRotation;
    private AudioSource hitAudio;
    // Start is called before the first frame update
    void Start()
    {
        handRotation = GameObject.Find("RightHandAnchor");
        hit = vrClient.cl.getCatchEvent();
        hitAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // this.gameObject.transform.rotation = this.gameObject.transform.parent.rotation;
        //gameObject.transform.eulerAngles = handRotation.transform.eulerAngles;
    }

    void OnCollisionEnter(Collision co){
        
        if (co.gameObject.tag == "Dokkaebi" && vrClient.cl.getCatchEvent() == 0)
        {
            Debug.Log("***BAT *** COLLISION WITH DOKKAEBI");
            co.gameObject.GetComponent<BasicGhostBehavior>().HitbyBat();
            Instantiate(hitEffectToSpawn, co.transform.position, Quaternion.identity);
            hitAudio.Play();
            vrClient.cl.setCatchEvent(1);
            Invoke("re_bat", 5f);
        }
        if(co.gameObject.tag == "Environment"){
            Debug.Log("***BAT *** COLLISION WITH ENVIRONMENT");
        }
        
    }

    void re_bat()
    {
        vrClient.cl.setCatchEvent(0);
    }
}
