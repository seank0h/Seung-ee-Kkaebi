using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;
    public float fireRate = 1f;
    public float timeBeforeDestroyed = 5f;
    private bool collided = false;
    private Rigidbody rb = null;
    public GameObject visualEffectToSpawn;
    public GameObject hitEffectToSpawn;

    void Start()
    {
        //vrClient.cl.setIsFlare(0);
        //Destroy(gameObject, timeBeforeDestroyed);
    }


    void OnCollisionEnter(Collision co){
        /*
        if (co.gameObject.tag != "Bullet" && !collided){
            collided = true;
            speed = 0f;
            Instantiate(visualEffectToSpawn, co.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        */
        if(co.gameObject.tag == "Dokkaebi"){
            speed = 0f;
            vrClient.cl.setBulletCollision(1);
            Instantiate(hitEffectToSpawn, co.transform.position, Quaternion.identity);
            Invoke("ServerMessage", 0.25f);
            Debug.Log("COLLISION WITH DOKKAEBI");
            
           
        }
    }
    void ServerMessage()
    {
        vrClient.cl.setBulletCollision(0);
        Destroy(gameObject);
    }
}
