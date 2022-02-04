using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAura : MonoBehaviour
{
    float timeForAura;
    bool auraOn;
    // Start is called before the first frame update
    void Start()
    {
        timeForAura = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (mobile2vr.mobileToVRCl.GhostBeingSeen())
        {
            this.gameObject.SetActive(true);
            auraOn = true;
         
        }
        if(timeForAura<=0)
        {
            this.gameObject.SetActive(false);
            auraOn = false;
        }
        Timer(auraOn);
    }
    void Timer(bool timerOn)
    {
        timeForAura -= Time.deltaTime;
    }
}
