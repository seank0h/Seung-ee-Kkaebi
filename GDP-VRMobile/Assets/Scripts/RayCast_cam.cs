using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast_cam : MonoBehaviour
{
    RaycastHit hit;
    Vector3 height = new Vector3(0, 0, 0);
    bool reset = false;
    Behaviour halo;

    float hold_time;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Dance();

    }

    private void Dance()
    {
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, 1000))
        {
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 1000, Color.red);
            if (hit.collider.tag == "Interactive")
            {
                Debug.Log(hit.collider.name);
                Debug.Log(hit.distance);
                if (hit.distance <= 100000)
                {
                    Debug.DrawRay(transform.position, transform.forward * 1000, Color.yellow);
                    halo = (Behaviour)hit.transform.gameObject.GetComponent("Halo");
                    halo.enabled = true;
                    reset = true;
                }
                if (Input.GetKey("q"))
                {
                    Debug.DrawRay(transform.position + height, transform.forward * 1000, Color.blue);
                    hold_time += Time.deltaTime;
                    Debug.Log(hold_time);
                    if (hold_time >= 3)
                    {
                        hold_time = 3;
                        hit.transform.gameObject.SetActive(false);
                        //Behaviour halo = (Behaviour)hit.transform.gameObject.GetComponent("Halo");
                        //halo.enabled = false;
                    }
                }
                //Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
                hold_time = 0;
                return;
            }
            else
            {
                hold_time = 0;
                if (reset)
                {
                    halo.enabled = false;
                    reset = false;
                }
            }
        }
        else
        {
            hold_time = 0;
        }

    }
}
