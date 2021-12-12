using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimationCall : MonoBehaviour
{
    private Animator animator;
    public Vector3 startPos;
    void Start()
    {
        animator = GetComponent<Animator>();
        startPos = this.gameObject.transform.parent.position;
         animator.Play("Korean_Male_Walk");
    }

    // Update is called once per frame
    void Update()
    {
        
           
        
    }
}
