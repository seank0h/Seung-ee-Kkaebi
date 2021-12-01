using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCStunHandler : MonoBehaviour
{
    //public List<GameObject> NPCList;
    // Start is called before the first frame update
    public SkinnedMeshRenderer npcRenderer;
    void Start()
    {

        /*
        for (int i = 0; i < NPCList.Count; i++)
        {
            NPCList[i].gameObject.GetComponent<Renderer>().material.color = Color.black;
        }
        */

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Stun Check: "+mobile2vr.mobileToVRCl.NPCStunState());
        /*
        if (mobile2vr.mobileToVRCl.NPCStunState() == 0)
        {
            NPCList[0].gameObject.GetComponent<Renderer>().material.color = Color.red;
            NPCList[0].gameObject.GetComponent<NavMeshAgent>().speed = 0;
            NPCList[0].gameObject.GetComponent<CapsuleCollider>().enabled = false;
            mobile2vr.mobileToVRCl.npcStunState = -1;
        }
        else if (mobile2vr.mobileToVRCl.NPCStunState() == 1)
        {
            NPCList[1].gameObject.GetComponent<Renderer>().material.color = Color.red;
            NPCList[1].gameObject.GetComponent<NavMeshAgent>().speed = 0;
            NPCList[1].gameObject.GetComponent<CapsuleCollider>().enabled = false;
            mobile2vr.mobileToVRCl.npcStunState = -1;
        }
        else if (mobile2vr.mobileToVRCl.NPCStunState() == 2)
        {
            NPCList[2].gameObject.GetComponent<Renderer>().material.color = Color.red;
            NPCList[2].gameObject.GetComponent<NavMeshAgent>().speed = 0;
            NPCList[2].gameObject.GetComponent<CapsuleCollider>().enabled = false;
            mobile2vr.mobileToVRCl.npcStunState = -1;
        }
        else if (mobile2vr.mobileToVRCl.NPCStunState() == 3)
        {
            NPCList[3].gameObject.GetComponent<Renderer>().material.color = Color.red;
            NPCList[3].gameObject.GetComponent<NavMeshAgent>().speed = 0;
            NPCList[3].gameObject.GetComponent<CapsuleCollider>().enabled = false;
            mobile2vr.mobileToVRCl.npcStunState = -1;
        }
        else if (mobile2vr.mobileToVRCl.NPCStunState() == 4)
        {
            NPCList[4].gameObject.GetComponent<Renderer>().material.color = Color.red;
            NPCList[4].gameObject.GetComponent<NavMeshAgent>().speed = 0;
            NPCList[4].gameObject.GetComponent<CapsuleCollider>().enabled = false;
            mobile2vr.mobileToVRCl.npcStunState = -1;
        }
        */
    }
    public void StunState()
    {
       npcRenderer.material.color = Color.red;
       this.gameObject.GetComponent<NavMeshAgent>().speed = 0;
       this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
    }
}
