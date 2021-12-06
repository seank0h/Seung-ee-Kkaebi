using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batMove : MonoBehaviour
{
    Vector3 pos;
    Vector3 rot;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        pos = mobileClient.cl.getBatPos();
        rot = mobileClient.cl.getBatRot();
        // Debug.Log("pos : " + pos);
        // Debug.Log("rot : " + rot);
        gameObject.transform.position = pos;
        gameObject.transform.rotation = Quaternion.Euler(rot[0], rot[1], rot[2]);
    }
}
