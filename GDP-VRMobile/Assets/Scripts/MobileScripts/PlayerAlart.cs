using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerAlart : MonoBehaviour
{
    public GameObject player;
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
    Raycast rc;
    bool proped;
    bool escaped = false;
    bool sturnable;
    GameObject npc;

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

        rc = player.GetComponent<Raycast>();
        proped = rc.proped;
        sturnable = player.GetComponent<Raycast>().sturnable;
        npc = player.GetComponent<Raycast>().npc;

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        proped = rc.proped;
        sturnable = player.GetComponent<Raycast>().sturnable;
        npc = player.GetComponent<Raycast>().npc;

        // Debug.Log("player mat : " + mobileClient.cl.getPlayerMat());

        if (sturn)
        {
            if (first)
            {
                Vibration.Vibrate(300);
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
                    // Debug.Log("°¡±î¿ò");
                    stay += Time.deltaTime;
                    release = 0;
                    if (stay >= 2f)
                    {
                        stay = 2f;
                        if (alart_first)
                        {
                            mobileClient.cl.setPlayerMat(1);
                            NPCaudio.clip = alertSound;
                            NPCaudio.Play();
                            //Debug.Log("sound");
                            npcRenderer.material.color = Color.blue;
                            this.gameObject.GetComponent<NavMeshAgent>().speed = 0;
                            // Debug.Log("alart npc cum : " + (index + 1));
                            //Debug.Log("NPC idx : " + index);
                            vr2mobile.vm.alert_send(index);
                            Vibration.Vibrate(1200);
                            // Debug.Log("alart npc ; " + gameObject.name);
                            alart_first = false;
                            escaped = true;
                        }
                    }
                }
                else if (distance > 5 && escaped)
                {
                    release += Time.deltaTime;
                    if (release >= 2)
                    {
                        escaped = false;
                        // Debug.Log("masaka");
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
    }

    void turn_back()
    {
        if (mobileClient.cl.getPlayerMat() == 1)
            mobileClient.cl.setPlayerMat(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("go sturn!");
        if (other.gameObject.tag == "NPC_sturn")
        {
            if (!player.GetComponent<Raycast>().sturnable)
            {
                player.GetComponent<Raycast>().sturnable = true;
                player.GetComponent<Raycast>().npc = this.gameObject;
            }
        }
        if (sturn)
        {
            player.GetComponent<Raycast>().sturnable = false;
            player.GetComponent<Raycast>().npc = null;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "NPC_sturn")
        {
            if (!player.GetComponent<Raycast>().sturnable)
            {
                player.GetComponent<Raycast>().sturnable = true;
                player.GetComponent<Raycast>().npc = this.gameObject;
            }
            if (sturn)
            {
                player.GetComponent<Raycast>().sturnable = false;
                player.GetComponent<Raycast>().npc = null;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "NPC_sturn")
        {
            player.GetComponent<Raycast>().sturnable = false;
            player.GetComponent<Raycast>().npc = null;
        }
        if (sturn)
        {
            player.GetComponent<Raycast>().sturnable = false;
            player.GetComponent<Raycast>().npc = null;
        }
    }
}
