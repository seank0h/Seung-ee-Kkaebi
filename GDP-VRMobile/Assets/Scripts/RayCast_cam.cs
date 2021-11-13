using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RayCast_cam : MonoBehaviour
{
    RaycastHit hit;
    Vector3 height = new Vector3(0, 0, 0);
    bool c_reset = false;
    Behaviour c_halo;
    bool n_reset = false;
    Behaviour n_halo;

    float c_hold_time = 0;
    float n_hold_time = 0;
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
        if (Physics.Raycast(gameObject.transform.position + height, gameObject.transform.forward, out hit, 1000))
        {
            Debug.DrawRay(gameObject.transform.position + height, gameObject.transform.forward * 1000, Color.red);
            if (hit.collider.tag == "Interactive")
            {
                //Debug.Log(hit.collider.name + " : " + hit.distance);
                if (hit.distance <= 3.0f)
                {
                    Debug.DrawRay(gameObject.transform.position + height, gameObject.transform.forward * 1000, Color.yellow);
                    c_halo = (Behaviour)hit.transform.gameObject.GetComponent("Halo");
                    c_halo.enabled = true;
                    c_reset = true;
                    //Debug.Log(hold_time);
                    if (Input.GetKey("q"))
                    {
                        Debug.DrawRay(gameObject.transform.position + height, gameObject.transform.forward * 1000, Color.blue);
                        c_hold_time += Time.deltaTime;
                        Debug.Log(c_hold_time);
                        if (c_hold_time >= 3.0f)
                        {
                            c_hold_time = 3.0f;
                            CurseManage curse = hit.collider.gameObject.GetComponent<CurseManage>();
                            curse.cursed = true;
                        }
                        return;
                    }
                    c_hold_time = 0;
                }
                return;
            }
            else if (hit.collider.tag == "NPC")
            {
                //Debug.Log(hit.collider.name + " : " + hit.distance);
                if (hit.distance <= 3.0f)
                {
                    Debug.DrawRay(gameObject.transform.position + height, gameObject.transform.forward * 1000, Color.yellow);
                    n_halo = (Behaviour)hit.transform.gameObject.GetComponent("Halo");
                    n_halo.enabled = true;
                    n_reset = true;
                    //Debug.Log(hold_time);
                    if (Input.GetKey("q"))
                    {
                        Debug.DrawRay(gameObject.transform.position + height, gameObject.transform.forward * 1000, Color.blue);
                        n_hold_time += Time.deltaTime;
                        Debug.Log(n_hold_time);
                        if (n_hold_time >= 0.8f)
                        {
                            n_hold_time = 0.8f;
                            hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
                        }
                        return;
                    }
                    n_hold_time = 0;
                }
                return;
            }
            else
            {
                n_hold_time = 0;
                c_hold_time = 0;
                if (c_reset)
                {
                    c_halo.enabled = false;
                    c_reset = false;
                }
                if (n_reset)
                {
                    n_halo.enabled = false;
                    n_reset = false;
                }
            }
        }
        else
        {
            c_hold_time = 0;
            n_hold_time = 0;
        }

    }
}
