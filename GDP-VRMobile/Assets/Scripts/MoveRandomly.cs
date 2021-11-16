using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveRandomly : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public float timeForNewPath;
    bool inCoRoutine;
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

        if(firstStart)
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
        
            if(patrolIndex==patrolPositions.Count)
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
            Debug.Log("GotToNewPosition");
            return true;
        }
        else
            return false;
        
    }

    void GetNewPath(){
        Debug.Log("Called GetNewPath");
        navMeshAgent.SetDestination(GetNewPosition());
    }
}
