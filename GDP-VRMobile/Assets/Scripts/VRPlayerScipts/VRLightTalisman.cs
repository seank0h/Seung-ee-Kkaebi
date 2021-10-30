using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLightTalisman : MonoBehaviour
{
    Renderer ghostRenderer;

    float timer = 5.0f;
    private void Start()
    {
        timer = 5.0f;
    }
    private void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if(other.gameObject.tag=="Ghost")
        {
            Debug.Log("Seeing Ghost");
            other.gameObject.GetComponent<BasicGhostBehavior>().BeingSeen();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ghost")
        {
            Debug.Log("Seeing Ghost");
            other.gameObject.GetComponent<BasicGhostBehavior>().NotSeen();
        }
    }
}
