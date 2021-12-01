using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAlertHandler : MonoBehaviour
{
    public SkinnedMeshRenderer npcRenderer;
    public void AlertState()
    {
        npcRenderer.GetComponent<Renderer>().material.color = Color.blue;
    }

    public void PatrolState()
    {
        npcRenderer.GetComponent<Renderer>().material.color = Color.black;
    }
    
}
