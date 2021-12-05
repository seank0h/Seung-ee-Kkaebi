using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLightTalisman : MonoBehaviour
{
    Renderer ghostRenderer;

    float timer = 10.0f;
    private void Start()
    {
        
        timer = 10.0f;
    }
    private void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            Destroy(this.gameObject);
        }
    }
}
