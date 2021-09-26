using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SearchLight : MonoBehaviour
{
    public Light lightSource;
    public float timeToKill;
    public float timer;
    public bool collidingWithGhost;
    public BasicGhostBehavior ghostEntity;
    // Start is called before the first frame update

    void Start()
    {
        lightSource = gameObject.GetComponentInParent<Light>();
        timer = timeToKill;
    }

    // Update is called once per frame
    void Update()
    {
        if(collidingWithGhost && lightSource.intensity > 0)
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

        Debug.Log("Colliding With Ghost");
        if(other.gameObject.tag=="Ghost")
        {
            collidingWithGhost = true;
            ghostEntity = other.gameObject.GetComponent<BasicGhostBehavior>();
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        timer = timeToKill;
        collidingWithGhost = false;
        Debug.Log("No Longer Colliding with Ghost");
    }

}
