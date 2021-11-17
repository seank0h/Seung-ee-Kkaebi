using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAlart : MonoBehaviour
{
    public GameObject player;
    float stay = 0;
    float release = 0;
    public bool sturn = false;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.black;
        speed = this.gameObject.GetComponent<NavMeshAgent>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (sturn)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
            this.gameObject.GetComponent<NavMeshAgent>().speed = 0;
        } else
        {
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
}
