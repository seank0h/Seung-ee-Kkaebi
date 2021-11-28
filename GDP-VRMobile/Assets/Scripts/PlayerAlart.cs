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
    int index;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.black;
        speed = this.gameObject.GetComponent<NavMeshAgent>().speed;
        if (gameObject.name == "NPC1")
        {
            index = 0;
        }
        else if (gameObject.name == "NPC2")
        {
            index = 1;
        }
        else if (gameObject.name == "NPC3")
        {
            index = 2;
        }
        else if (gameObject.name == "NPC4")
        {
            index = 3;
        }
        else if (gameObject.name == "NPC5")
        {
            index = 4;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (sturn)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
            this.gameObject.GetComponent<NavMeshAgent>().speed = 0;
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
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
                    vr2mobile.vm.alert_send(index);
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
                vr2mobile.vm.alert_end(index);
            }
        }
    }
}
