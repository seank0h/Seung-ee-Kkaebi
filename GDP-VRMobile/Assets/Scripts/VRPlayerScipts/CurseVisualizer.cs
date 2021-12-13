using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseVisualizer : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> curseableHouses;
    public GameObject curseEffectSystem;
    public GameObject particleSystemForVillageStatus;
    public GameObject Trail_One;
    public GameObject Trail_Two;
    public GameObject Trail_Three;
    public GameObject Trail_Four;
    public GameObject particleLights;
    public GameObject treeParticleSystem;
    public bool curseOne = false;
    
    public bool curseTwo = false;

    public bool curseThree = false;

    public bool curseFour = false;

    public GameObject gaugeBall;
    LiquidVolumeFX.LiquidVolume gaugeBallLiquidVolume;
    private Renderer gaugeBallMaterial;
    public bool villagePranked;
    public bool villageHalfPranked;
    public float fillSpeed=0.03f;
    float fillamount;
    void Start()
    {
        gaugeBallMaterial = gaugeBall.GetComponent<Renderer>();
        gaugeBallLiquidVolume = gaugeBall.GetComponent<LiquidVolumeFX.LiquidVolume>();
    }
    private void Update()
    {
      
        //if (mobile2vr.mobileToVRCl.CurseDetection()!=-1)
        InstantiateCurseEffect();
        if(gaugeBallLiquidVolume.level==1)
        {
            villagePranked = true;
            treeParticleSystem.SetActive(true);
        }
        if(gaugeBallLiquidVolume.level >=0.5f)
        {
            villageHalfPranked = true;
        }
        if (gaugeBallLiquidVolume.level < fillamount)
        {
            gaugeBallLiquidVolume.level += fillSpeed;
        }
    }
    void InstantiateCurseEffect()
    {
        //if(mobile2vr.mobiletoVRCl.startNPC==0)
        //if(mobile2vr.mobiletoVRCl.startNPC==1)
        //if(mobile2vr.mobiletoVRCl.startNPC==2)
        //if(mobile2vr.mobiletoVRCl.startNPC==3)
        if (mobile2vr.mobileToVRCl.CurseDetection() == 0 || Input.GetKey(KeyCode.P))
        {

           
            if (particleSystemForVillageStatus.activeInHierarchy != true)
            {
                particleSystemForVillageStatus.SetActive(true);
                particleLights.SetActive(true);
             
            }
            if(curseOne==false)
            {
                 Instantiate(curseEffectSystem, curseableHouses[0].transform.position, Quaternion.identity);
               
               
                fillamount = gaugeBallLiquidVolume.level += 0.25f;

                Trail_One.SetActive(true);
            curseOne = true;
            }
            
        }
        else if (mobile2vr.mobileToVRCl.CurseDetection() == 1 || Input.GetKey(KeyCode.P))
        {

           
            if (particleSystemForVillageStatus.activeInHierarchy != true)
            {
                particleSystemForVillageStatus.SetActive(true);
                particleLights.SetActive(true);
            }
            if(curseTwo==false)
            {
                 Instantiate(curseEffectSystem, curseableHouses[1].transform.position, Quaternion.identity);
                fillamount = gaugeBallLiquidVolume.level += 0.25f;
                Trail_Two.SetActive(true);
            curseTwo = true;

            }
            
            
        }
        else if (mobile2vr.mobileToVRCl.CurseDetection() == 2 || Input.GetKey(KeyCode.P))
        {
            
      
            if (particleSystemForVillageStatus.activeInHierarchy != true)
            {
                particleSystemForVillageStatus.SetActive(true);
                particleLights.SetActive(true);
            }
            if(curseThree==false)
            {
                      Instantiate(curseEffectSystem, curseableHouses[2].transform.position, Quaternion.identity);
                fillamount = gaugeBallLiquidVolume.level += 0.25f;
                Trail_Three.SetActive(true);
            curseThree = true;
            }
            
        }
        else if (mobile2vr.mobileToVRCl.CurseDetection() == 3 || Input.GetKey(KeyCode.P))
        {

            
            if (particleSystemForVillageStatus.activeInHierarchy != true)
            {
                particleSystemForVillageStatus.SetActive(true);
                particleLights.SetActive(true);
            }
            if(curseFour==false)
            {
                Instantiate(curseEffectSystem, curseableHouses[3].transform.position, Quaternion.identity);
                fillamount = gaugeBallLiquidVolume.level += 0.25f;
                Trail_Four.SetActive(true);
            curseFour = true;
            }
           
        }
    }
}
