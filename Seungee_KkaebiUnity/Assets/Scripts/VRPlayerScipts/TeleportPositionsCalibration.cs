using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPositionsCalibration : MonoBehaviour
{
    public float yPositionCalibration;
    void Start()
    {
        yPositionCalibration = GameObject.Find("OVRCameraRig").transform.position.y;
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x,yPositionCalibration, this.gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
