using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAlertHandler : MonoBehaviour
{
    public GameObject player;
    float stay = 0;
    float release = 0;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = this.gameObject.GetComponent<NavMeshAgent>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= 5)
            {
                stay += Time.deltaTime;
                release = 0;
                if (stay >= 2f)
                {
                    this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
                    this.gameObject.GetComponent<NavMeshAgent>().speed = 0;
                }
            }
            else
            {
                release += Time.deltaTime;
                if (release <= 2)
                {
                    return;
                }
                stay = 0;
                release = 0;
                this.gameObject.GetComponent<Renderer>().material.color = Color.black;
                this.gameObject.GetComponent<NavMeshAgent>().speed = speed;
            }
    }
    
}
