using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SearchLight : MonoBehaviour
{
    
    [Header ("Light Data")]
    public GameObject lightEntity;
    public Light lightSource;
    public bool lightOn;
    [Header("Spotlight Settings")]
    public float radius;
    public float range;
    [Range(0,360)]
    public float angle;
    public LayerMask targetMask;
    public LayerMask obstructionMask;
    public bool canSeeGhost = false;

    public BasicGhostBehavior currGhostSeen;

    // Start is called before the first frame update
    void Start()
    {
        lightSource = lightEntity.GetComponent<Light>();
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
            Debug.Log("Light On");
            lightOn = true;
        }
        else if (lightSource.intensity == 0)
        {
            Debug.Log("Light Off");
            lightOn = false;
        }
        if (lightOn)
            LineOfSightCheck();

    }
    private void GhostCheck()
    {
        if (currGhostSeen !=null)
        {
            if (canSeeGhost)
            {
                currGhostSeen.beingSeen = true;
            }
            else
            {
                currGhostSeen.beingSeen = false;
            }
        }
    }
    private void LineOfSightCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if(rangeChecks.Length!=0)
        {
            Transform target = rangeChecks[0].transform;
            currGhostSeen = target.GetComponent<BasicGhostBehavior>();
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
