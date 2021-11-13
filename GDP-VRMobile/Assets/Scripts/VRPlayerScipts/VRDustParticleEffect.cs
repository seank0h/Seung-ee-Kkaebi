using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRDustParticleEffect : MonoBehaviour
{

   public ParticleSystem dustEffect;
    bool effectOn;
    float lowerEmissionRate;
    float NormalEmissionRate;
    void Start()
    {
        effectOn = false;
        NormalEmissionRate = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
        
            if (effectOn == false)
            {
                var dustEffectEmission = dustEffect.emission;
                dustEffectEmission.rateOverTime = NormalEmissionRate;
                dustEffect.Play();
                effectOn = true;
            }
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            if (effectOn)
            {
                var dustEffectEmission = dustEffect.emission;
                lowerEmissionRate--;
                dustEffectEmission.rateOverTime = lowerEmissionRate;
                effectOn = false;
            }
        }

    }

}
