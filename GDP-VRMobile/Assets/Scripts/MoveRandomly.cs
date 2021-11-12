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
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(!inCoRoutine) StartCoroutine(coRoutine());
    }

    Vector3 getNewRandomPosition(){
        float x = Random.Range(-20, 20);
        float z = Random.Range(-20, 20);
        
        Vector3 pos = new Vector3(x, 0, z);
        return pos;
    }

    IEnumerator coRoutine(){
        inCoRoutine = true;
        yield return new WaitForSeconds(timeForNewPath);
        GetNewPath();
        inCoRoutine = false;
    }

    void GetNewPath(){
        navMeshAgent.SetDestination(getNewRandomPosition());
    }
}
