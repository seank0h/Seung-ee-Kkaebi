using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    RaycastHit hit;
    Vector3 height = new Vector3(0,1.375f,0);
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
        if (Physics.Raycast(gameObject.transform.position + height, gameObject.transform.forward, out hit, 1000))
        {
            Debug.DrawRay(transform.position + height, transform.forward * 1000, Color.red);
            if (hit.collider.name == "dance1")
            {
                Debug.Log(hit.collider.name);
                Debug.Log(hit.distance);
                if (Input.GetKey("q"))
                {
                    Debug.DrawRay(transform.position + height, transform.forward * 1000, Color.blue);
                    hold_time += Time.deltaTime;
                    Debug.Log(hold_time);
                    if (hold_time >= 3)
                    {
                        hit.transform.gameObject.SetActive(false);
                    }
                }
                //Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
                return;
            }
            else
            {
                hold_time = 0;
            }
        }
        else
        {
            hold_time = 0;
        }

    }
}
