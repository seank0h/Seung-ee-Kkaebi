using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SearchLight : MonoBehaviour
{
    public GameObject lightEntity;
    public Light lightSource;
    public bool lightOn;
    [Header ("Ghost Data")]
    public float timeToKill;
    public float timer;
    public bool collidingWithGhost;
    public GameObject[] ghostObjects;
    public BasicGhostBehavior[] ghostEntities;
    [Header("Spotlight Settings")]
    public float radius;
    public float range;
    [Range(0,360)]
    public float angle;
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public bool canSeeGhost = false;

    public GameObject blockedBy;
    // Start is called before the first frame update
    void Start()
    {
        lightSource = lightEntity.GetComponent<Light>();
        timer = timeToKill;
        for (int i = 0; i < ghostEntities.Length; i++)
        {
            ghostEntities[i] = ghostObjects[i].GetComponent<BasicGhostBehavior>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        LightCheck();
        GhostCheck();

    }
    private void LightCheck()
    {
        if (lightSource.intensity > 0)
        {
            lightOn = true;
        }
        else if (lightSource.intensity == 0)
        {
            lightOn = false;
        }
        if (lightOn)
            LineOfSightCheck();

    }
    private void GhostCheck()
    {
        if (canSeeGhost)
        {
            if (lightSource.intensity > 0)
                ghostEntities[0].beingSeen = true;
            else
                ghostEntities[0].beingSeen = false;
        }
       
    }
    /*
    private void OnTriggerStay(Collider other)
    {
        if(Physics.Raycast(transform.position,transform.forward,20))
        {
            if(other.gameObject.tag=="Ghost")
            {
                canSeeGhost = true;
                collidingWithGhost = true;
                Debug.Log("Colliding With Ghost");
                ghostEntity = other.gameObject.GetComponent<BasicGhostBehavior>();          
            }
            if(other.gameObject.tag=="Environment"){
                collidingWithGhost = false;
                canSeeGhost = false;
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

        canSeeGhost = false;
        blockedBy = null;
    }
    */
    private void LineOfSightCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if(rangeChecks.Length!=0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if(!Physics.Raycast(transform.position,directionToTarget,distanceToTarget,obstructionMask))
                {
                    canSeeGhost = true;
                    Debug.Log("Can See Ghost");
                }
                    
                else
                    canSeeGhost = false;
             

            }
            else
                canSeeGhost = false;
        }
        else if(canSeeGhost)
        {
            canSeeGhost = false;
        }
    }
}
