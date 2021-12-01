using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAlart : MonoBehaviour
{
    public GameObject player;
    public GameObject prop;
    float stay = 0;
    float release = 0;
    float sturn_time = 0;
    public bool sturn = false;
    public bool sturning = false;
    float speed;
    int index;
    RayCast_cam pp;
    bool proped;

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

        pp = prop.GetComponent<RayCast_cam>();
        proped = pp.proped;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        proped = pp.proped;

        // Debug.Log(proped);

        if (sturn)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
            this.gameObject.GetComponent<NavMeshAgent>().speed = 0;
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;

            vr2mobile.vm.strun_send(index);
        }
        else
        {
            if (sturning)
            {
                sturn_time += Time.deltaTime;
                if (sturn_time >= 0.8f)
                {
                    sturn_time = 0.8f;
                    sturn = true;
                    // Debug.Log("sturn npc ; " + gameObject.name);
                    return;
                }
            }
            else
            {
                sturn_time -= Time.deltaTime / 3;
                if (sturn_time <= 0)
                    sturn_time = 0;
            }

            if (!proped)
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
                        // Debug.Log("alart npc ; " + gameObject.name);
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
}
