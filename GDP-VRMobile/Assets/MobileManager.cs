using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileManager : MonoBehaviour
{
    public List<GameObject> ghostObjects;
    public List<BasicGhostBehavior> ghostEntities;
    void Start()
    {
        for (int i = 0; i < ghostObjects.Count; i++)
        {
            ghostEntities.Add(ghostObjects[i].GetComponent<BasicGhostBehavior>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealthPoints();
    }

    void CheckHealthPoints()
    {
        for (int i = 0; i < ghostEntities.Count; i++)
        {
            if(ghostEntities[i].healthPoints<=0)
            {
                ghostEntities[i].shouldDie = true;
                ghostEntities.Remove(ghostEntities[i]);
            }
        }
    }
}
