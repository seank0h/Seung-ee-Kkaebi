using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateAura : MonoBehaviour
{
    float timeForAura;
    bool auraOn;
    public GameObject dokkaebiAura;
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
            dokkaebiAura.SetActive(true);
            Debug.Log("Aura Should be active");
            auraOn = true;
        }
        if(timeForAura<=0)
        {
            dokkaebiAura.SetActive(false);
            auraOn = false;
        }
        Timer(auraOn);
        Debug.Log("Aura On: " + auraOn);
    }
    void Timer(bool timerOn)
    {
        timeForAura -= Time.deltaTime;
    }
}
