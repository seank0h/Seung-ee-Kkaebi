using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerAlart : MonoBehaviour
{
    public GameObject player;
    public GameObject prop;
    public SkinnedMeshRenderer npcRenderer;
    public Slider curse_slide;
    float stay = 0;
    float release = 0;
    public float sturn_time = 0;
    public bool sturn = false;
    public bool sturning = false;
    bool first = true;
    bool alart_first = true;
    float speed;
    int index;
    RayCast_cam pp;
    bool proped;

    public AudioClip alertSound, sturnSound;
    private AudioSource NPCaudio;

    // Start is called before the first frame update
    void Start()
    {
        NPCaudio = GetComponent<AudioSource>();
        npcRenderer.material.color = Color.black;
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
            if (first)
            {
                NPCaudio.clip = sturnSound;
                NPCaudio.Play();
                npcRenderer.material.color = Color.red;
                this.gameObject.GetComponent<NavMeshAgent>().speed = 0;
                this.gameObject.GetComponent<CapsuleCollider>().enabled = false;

                // Debug.Log("sturn npc cum : " + (index+1));
                curse_slide.value += 5;
                vr2mobile.vm.strun_send(index);
                first = false;
                Invoke("turn_back", 2f);
            }
            
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
                        
                        if (alart_first)
                        {
                            NPCaudio.clip = alertSound;
                            NPCaudio.Play();
                            //Debug.Log("sound");
                            npcRenderer.material.color = Color.blue;
                            this.gameObject.GetComponent<NavMeshAgent>().speed = 0;
                            // Debug.Log("alart npc cum : " + (index + 1));
                            mobileClient.cl.setPlayerMat(1);
                            vr2mobile.vm.alert_send(index);
                            // Debug.Log("alart npc ; " + gameObject.name);
                            alart_first = false;
                        }
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
                    npcRenderer.material.color = Color.black;
                    this.gameObject.GetComponent<NavMeshAgent>().speed = speed;
                    //Debug.Log("repatroll npc cum : " + (index + 1));
                    mobileClient.cl.setPlayerMat(0);
                    alart_first = true;
                    vr2mobile.vm.alert_end(index);
                }
            }
        }
    }

    void turn_back()
    {
        if (mobileClient.cl.getPlayerMat() == 1)
            mobileClient.cl.setPlayerMat(0);
    }
}