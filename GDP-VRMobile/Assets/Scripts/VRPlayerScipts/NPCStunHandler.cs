using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCStunHandler : MonoBehaviour
{
    //public List<GameObject> NPCList;
    // Start is called before the first frame update
    public SkinnedMeshRenderer npcRenderer;
    public GameObject animatorEntity;
    public NPCAnimationCallVR animatorNPC;
    void Start()
    {
        animatorNPC = animatorEntity.GetComponent<NPCAnimationCallVR>();
        
    }

   
    void Update()
    {
       
    }
    public void StunState()
    {
        Debug.Log("StunState");
        npcRenderer.material.color = Color.red;
       this.gameObject.GetComponent<NavMeshAgent>().speed = 0;
       this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        animatorNPC.CallStandAnimation();
    }
}
