using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseVisualizer : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> curseableHouses;
    Behaviour halo; 
    Behaviour halo1;
    Behaviour halo2;
    Behaviour halo3;
    void Start()
    {
        halo = (Behaviour)curseableHouses[0].gameObject.GetComponent("Halo");
        halo1 = (Behaviour)curseableHouses[1].gameObject.GetComponent("Halo");
        halo2 =  (Behaviour)curseableHouses[2].gameObject.GetComponent("Halo");
        halo3 = (Behaviour)curseableHouses[3].gameObject.GetComponent("Halo");
    }
    private void Update()
    {
        if(mobile2vr.mobileToVRCl.CurseDetection()!=-1)
        TurnOnHalo();
    }
    void TurnOnHalo()
    {
        if(mobile2vr.mobileToVRCl.CurseDetection()==0)
        {
            halo.enabled = true;
        }
        else if (mobile2vr.mobileToVRCl.CurseDetection() == 1)
        {
            halo1.enabled = true;
        }
        else if(mobile2vr.mobileToVRCl.CurseDetection() == 2)
        {
            halo2.enabled = true;
        }
        else if(mobile2vr.mobileToVRCl.CurseDetection() == 3)
            halo3.enabled = true;
        
    }
}
