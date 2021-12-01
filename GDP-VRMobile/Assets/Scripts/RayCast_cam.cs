using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.EventSystems;


public class RayCast_cam : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    RaycastHit hit;
    Vector3 height = new Vector3(0, 0, 0);
    bool c_reset = false;
    Behaviour c_halo;
    bool n_reset = false;
    Behaviour n_halo;
    bool p_reset = false;
    Behaviour p_halo;
    private bool isBtnDown = false;

    CurseManage curse;
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

    public void OnPointerDown(PointerEventData eventData)
    {
        isBtnDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isBtnDown = false;
    }

    public void Dance()
    {
        if (Physics.Raycast(gameObject.transform.position + height, gameObject.transform.forward, out hit, 1000))
        {
            Debug.DrawRay(gameObject.transform.position + height, gameObject.transform.forward * 1000, Color.red);
            if (hit.collider.tag == "Interactive") //건물 저주
            {
                n_hold_time = 0;
                if (n_reset)
                {
                    n_halo.enabled = false;
                    n_reset = false;
                }
                if (p_reset)
                {
                    p_halo.enabled = false;
                    p_reset = false;
                }

                if (hit.distance <= 3.0f)
                {
                    Debug.DrawRay(gameObject.transform.position + height, gameObject.transform.forward * 1000, Color.yellow);
                    c_halo = (Behaviour)hit.transform.gameObject.GetComponent("Halo");
                    c_halo.enabled = true;
                    c_reset = true;
                    if (Input.GetKey("q") || isBtnDown)
                    {
                        Debug.DrawRay(gameObject.transform.position + height, gameObject.transform.forward * 1000, Color.blue);
                        curse = hit.collider.gameObject.GetComponent<CurseManage>();
                        curse.cursing = true;
                    }
                }
                return;
            }
            else if (hit.collider.tag == "NPC") // npc 스턴
            {
                if (c_reset)
                {
                    curse.cursing = false;
                    c_halo.enabled = false;
                    c_reset = false;
                }
                if (p_reset)
                {
                    p_halo.enabled = false;
                    p_reset = false;
                }
                //Debug.Log(hit.collider.name + " : " + hit.distance);
                if (hit.distance <= 3.0f)
                {
                    Debug.DrawRay(gameObject.transform.position + height, gameObject.transform.forward * 1000, Color.yellow);
                    n_halo = (Behaviour)hit.transform.gameObject.GetComponent("Halo");
                    n_halo.enabled = true;
                    n_reset = true;
                    //Debug.Log(hold_time);
                    Debug.Log(vr2mobile.vm);
                    if (Input.GetKey("q") || isBtnDown)
                    {
                        Debug.DrawRay(gameObject.transform.position + height, gameObject.transform.forward * 1000, Color.blue);
                        n_hold_time += Time.deltaTime;
                        //Debug.Log(n_hold_time);
                        if (n_hold_time >= 0.8f)
                        {
                            n_hold_time = 0.8f;
                            PlayerAlart sturned = hit.collider.gameObject.GetComponent<PlayerAlart>();
                            sturned.sturn = true;

                            if (hit.collider.gameObject.name == "NPC1")
                            {
                                vr2mobile.vm.strun_send(0);
                            }
                            else if (hit.collider.gameObject.name == "NPC2")
                            {
                                vr2mobile.vm.strun_send(1);
                            }
                            else if (hit.collider.gameObject.name == "NPC3")
                            {
                                vr2mobile.vm.strun_send(2);
                            }
                            else if (hit.collider.gameObject.name == "NPC4")
                            {
                                vr2mobile.vm.strun_send(3);
                            }
                            else if (hit.collider.gameObject.name == "NPC5")
                            {
                                vr2mobile.vm.strun_send(4);
                            }
                        }
                        return;
                    }
                    n_hold_time = 0;
                }
                return;
            }
            else if (hit.collider.tag == "Prop")
            {
                n_hold_time = 0;
                if (c_reset)
                {
                    curse.cursing = false;
                    c_halo.enabled = false;
                    c_reset = false;
                }
                if (n_reset)
                {
                    n_halo.enabled = false;
                    n_reset = false;
                }
                if (hit.distance <= 3.0f)
                {
                    Debug.DrawRay(gameObject.transform.position + height, gameObject.transform.forward * 1000, Color.yellow);
                    p_halo = (Behaviour)hit.transform.gameObject.GetComponent("Halo");
                    p_halo.enabled = true;
                    p_reset = true;
                    //Debug.Log(hold_time);
                    if (Input.GetKey("q"))
                    {
                        Debug.Log("prop");
                    }
                }
                return;
            }
            else
            {
                n_hold_time = 0;
                if (c_reset)
                {
                    curse.cursing = false;
                    c_halo.enabled = false;
                    c_reset = false;
                }
                if (n_reset)
                {
                    n_halo.enabled = false;
                    n_reset = false;
                }
                if (p_reset)
                {
                    p_halo.enabled = false;
                    p_reset = false;
                }
            }
        }
        else
        {
            curse.cursing = false;
            n_hold_time = 0;
        }

    }
}
    