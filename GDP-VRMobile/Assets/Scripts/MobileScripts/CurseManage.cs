using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class CurseManage : MonoBehaviour
{
    public bool cursed = false;
    public GameObject curseStatus;
    Behaviour halo;
    public float curse_time;
    public bool cursing = false;
    public GameObject curseEffect;
    bool first = true;

    // Start is called before the first frame update
    void Start()
    {
        halo = (Behaviour)this.gameObject.GetComponent("Halo");
    }

    // Update is called once per frame
    void Update()
    {
        if (cursed) {
            if (first)
            {
                Vibration.Vibrate(1000);
                Instantiate(curseEffect, gameObject.transform.position, Quaternion.identity);

                curseStatus.GetComponent<progressLiquid>().increaseLevel(25);

                // 저주받은 건물의 번호를 서버를 통해 전송
                if (gameObject.name == "curse1")
                {
                    vr2mobile.vm.curse_send(0);
                    mobileClient.cl.setstartNPCMove(0);
                }
                else if (gameObject.name == "curse2")
                {
                    vr2mobile.vm.curse_send(1);
                    mobileClient.cl.setstartNPCMove(1);
                }
                else if (gameObject.name == "curse3")
                {
                    vr2mobile.vm.curse_send(2);
                    mobileClient.cl.setstartNPCMove(2);
                }
                else if (gameObject.name == "curse4")
                {
                    vr2mobile.vm.curse_send(3);
                    mobileClient.cl.setstartNPCMove(3);
                }

                first = false;
            }

        }
        else
        {
            if (cursing)
            {
                curse_time += Time.deltaTime;

                // Debug.Log("hold time : " + curse_time);

                if(curse_time >= 15.0f)
                {
                    curse_time = 15.0f;
                    cursed = true;
                }
            }
            else
            {
                curse_time -= Time.deltaTime / 5;

                if (curse_time <= 0)
                    curse_time = 0;
            }
        }
    }
}
