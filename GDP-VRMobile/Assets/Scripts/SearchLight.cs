using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SearchLight : MonoBehaviour
{
    public float timeToKill;
    public float timer;
    public bool collidingWithGhost;
    public BasicGhostBehavior ghostEntity;

    public bool blocked = false;
    public GameObject blockedBy;
    // Start is called before the first frame update
    void Start()
    {
        timer = timeToKill;
    }

    // Update is called once per frame
    void Update()
    {
        if(collidingWithGhost)
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ghostEntity.Death();
            timer = timeToKill;
            ghostEntity = null;
            collidingWithGhost = false;
        }
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward,20)){

            if(other.gameObject.tag=="Ghost" && !blocked){
                collidingWithGhost = true;
                Debug.Log("Colliding With Ghost");
                ghostEntity = other.gameObject.GetComponent<BasicGhostBehavior>();          
            }
            if(other.gameObject.tag=="Environment"){
                collidingWithGhost = false;
                blocked = true;
                blockedBy = other.gameObject;
                Debug.Log("Colliding With Environment");
            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        timer = timeToKill;
        collidingWithGhost = false;
        Debug.Log("No Longer Colliding with Ghost");

        blocked = false;
        blockedBy = null;
    }
}
