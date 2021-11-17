using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveRandomly : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public float timeForNewPath;
    public List<GameObject> patrolPositions;
    [SerializeField]
    int patrolIndex;
    [SerializeField]
    Vector3 newPatrolPos;
    bool firstStart;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        firstStart = true;

    }

    // Update is called once per frame
    void Update()
    {
        // (mobile2vr.mobileToVRCl.NPCMovementStart()) || vr2mobile.vm.go()
        if (firstStart && mobile2vr.mobileToVRCl.NPCMovementStart())
        {
            GetNewPath();
            firstStart = false;
        }
        if (GotToNewPosition())
        {
            GetNewPath();
        }
    }

    Vector3 GetNewPosition(){
        if (patrolIndex == patrolPositions.Count - 1)
        {
            patrolIndex = 0;
        }
        else
            patrolIndex++;

        newPatrolPos = patrolPositions[patrolIndex].transform.position;
        return newPatrolPos;
    }
    bool GotToNewPosition()
    {
        if (gameObject.transform.position.x == newPatrolPos.x && gameObject.transform.position.z==newPatrolPos.z)
        {
            
            return true;
        }
        else
            return false;
        
    }

    void GetNewPath(){
       
        navMeshAgent.SetDestination(GetNewPosition());
    }
}
