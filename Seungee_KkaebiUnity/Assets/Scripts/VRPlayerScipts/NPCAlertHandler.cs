using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAlertHandler : MonoBehaviour
{
    public SkinnedMeshRenderer npcRenderer;
    public GameObject dokkaebiEntity;
    public BasicGhostBehavior dokkaebiBehavior;
    public GameObject animatorEntity;
    public NPCAnimationCallVR animatorNPC;
    private void Start()
    {
        npcRenderer.material.color = Color.black;
        dokkaebiBehavior = dokkaebiEntity.GetComponent<BasicGhostBehavior>();
        animatorNPC = animatorEntity.GetComponent<NPCAnimationCallVR>();
    }
    public void AlertState()
    {
        dokkaebiBehavior.beingSeen = true;
        Invoke("StopBeingSeen", 2f);
        npcRenderer.material.color = Color.blue;
        animatorNPC.CallStandAnimation();
    }
    
    public void PatrolState()
    {
        npcRenderer.material.color = Color.white;
        animatorNPC.CallWalkAnimation();
    }
    
    void StopBeingSeen()
    {
        dokkaebiBehavior.beingSeen = false;
    }
}
