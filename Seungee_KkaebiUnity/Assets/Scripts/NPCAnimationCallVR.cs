using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimationCallVR : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Korean_Male_Walk");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallWalkAnimation()
    {
        animator.Play("Korean_Male_Walk");
    }
    public void CallStandAnimation()
    {
        animator.Play("Korean_Male_Stand");
    }
}
