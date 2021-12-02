using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAlertHandler : MonoBehaviour
{
    public SkinnedMeshRenderer npcRenderer;
    public GameObject dokkaebiEntity;
    public BasicGhostBehavior dokkaebiBehavior;

    private void Start()
    {
        npcRenderer.material.color = Color.black;
        dokkaebiBehavior = dokkaebiEntity.GetComponent<BasicGhostBehavior>();
    }
    public void AlertState()
    {
        dokkaebiBehavior.beingSeen = true;
        Invoke("StopBeingSeen", 5f);
        npcRenderer.material.color = Color.blue;
    }
    
    public void PatrolState()
    {
        npcRenderer.material.color = Color.black;
    }
    
    void StopBeingSeen()
    {
        dokkaebiBehavior.beingSeen = false;
    }
}
