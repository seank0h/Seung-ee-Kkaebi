using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimationCall : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Korean_Male_Walk");
    }

    // Update is called once per frame
    void Update()
    {
        
           
        
    }
}
