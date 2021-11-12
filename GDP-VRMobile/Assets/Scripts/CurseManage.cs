using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CurseManage : MonoBehaviour
{
    public bool cursed = false;
    Behaviour halo;
    SerializedObject halo2;
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
            halo.enabled = true;
            halo2.FindProperty("m_Color").colorValue = Color.magenta;
            halo2.ApplyModifiedProperties();
        }
        else
        {
            halo.enabled = false;
            halo2.FindProperty("m_Color").colorValue = Color.white;
            halo2.ApplyModifiedProperties();
        }
    }
}
