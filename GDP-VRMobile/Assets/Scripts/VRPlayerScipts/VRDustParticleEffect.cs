using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRDustParticleEffect : MonoBehaviour
{

   public ParticleSystem dustEffect;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            dustEffect.Play();
        }
    }
}
