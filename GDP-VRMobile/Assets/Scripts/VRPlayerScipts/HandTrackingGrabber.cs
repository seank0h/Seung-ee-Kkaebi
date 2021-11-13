using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class HandTrackingGrabber : OVRGrabber
{
    private OVRHand hand;
    public float pinchThreshold = 0.7f;

    protected override void Start()
    {
        base.Start();
        hand = GetComponent<OVRHand>();
    }

    public override void Update()
    {
        base.Update();
        CheckIndexPinch();
    }

    void CheckIndexPinch()
    {
        float pinchStrength = GetComponent<OVRHand>().GetFingerPinchStrength(OVRHand.HandFinger.Index);
        bool isPinching = pinchStrength > pinchThreshold;

        if(!m_grabbedObj && isPinching && m_grabCandidates.Count > 0)
            GrabBegin();
        else if(m_grabbedObj && !isPinching)
            GrabEnd();
    }

    // Enable throwing of the obj
    protected override void GrabEnd()
    {
        if(m_grabbedObj)
        {
            Vector3 linearVelocity = (transform.parent.position - m_lastPos) / Time.fixedDeltaTime;
            Vector3 angularVelocity = (transform.parent.eulerAngles - m_lastRot.eulerAngles) / Time.fixedDeltaTime;

            GrabbableRelease(linearVelocity, angularVelocity);
        }

        GrabVolumeEnable(true);
    }
}
