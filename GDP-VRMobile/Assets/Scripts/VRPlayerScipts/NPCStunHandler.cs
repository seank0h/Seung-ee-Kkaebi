using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCStunHandler : MonoBehaviour
{
    //public List<GameObject> NPCList;
    // Start is called before the first frame update
    public SkinnedMeshRenderer npcRenderer;
    public GameObject gaugeBall;
    private Renderer gaugeBallMaterial;
    void Start()
    {
        gaugeBallMaterial = gaugeBall.GetComponent<Renderer>();
        
    }

   
    void Update()
    {
       
    }
    public void StunState()
    {
        Debug.Log("StunState");
        float fillAmount = gaugeBallMaterial.material.GetFloat("_Cutoff") - 0.05f;
        gaugeBallMaterial.material.SetFloat("_Cutoff", fillAmount);
        npcRenderer.material.color = Color.red;
       this.gameObject.GetComponent<NavMeshAgent>().speed = 0;
       this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
    }
}
