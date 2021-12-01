using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CurseManage : MonoBehaviour
{
    public bool cursed = false;
    Behaviour halo;
    SerializedObject halo2;
    public float curse_time;
    public bool cursing = false;

    // Start is called before the first frame update
    void Start()
    {
        halo = (Behaviour)this.gameObject.GetComponent("Halo");
        halo2 = new SerializedObject(this.gameObject.GetComponent("Halo"));
        halo2.FindProperty("m_Color").colorValue = Color.white;
        halo2.ApplyModifiedProperties();
    }

    // Update is called once per frame
    void Update()
    {
        if (cursed) {
            halo2.FindProperty("m_Color").colorValue = Color.magenta;
            halo2.ApplyModifiedProperties();
            halo.enabled = true;

            // 저주받은 건물의 번호를 서버를 통해 전송
            if (gameObject.name == "curse1")
            {
                vr2mobile.vm.curse_send(0);
            }
            else if (gameObject.name == "curse2")
            {
                vr2mobile.vm.curse_send(1);
            }
            else if (gameObject.name == "curse3")
            {
                vr2mobile.vm.curse_send(2);
            }
            else if (gameObject.name == "curse4")
            {
                vr2mobile.vm.curse_send(3);
            }
            // Debug.Log("curse house : " + gameObject.name);
        }
        else
        {
            halo2.FindProperty("m_Color").colorValue = Color.white;
            halo2.ApplyModifiedProperties();

            if (cursing)
            {
                curse_time += Time.deltaTime;

                Debug.Log("hold time : " + curse_time);

                if(curse_time >= 3.0f)
                {
                    curse_time = 3.0f;
                    cursed = true;
                }
            }
            else
            {
                curse_time -= Time.deltaTime / 3;

                if (curse_time <= 0)
                    curse_time = 0;
            }
        }
    }
}
