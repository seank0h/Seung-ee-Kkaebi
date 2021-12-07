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

    public GameObject gaugeBall;
    private Renderer gaugeBallMaterial;
    public bool villagePranked;
    public bool villageHalfPranked;
    void Start()
    {
        gaugeBallMaterial = gaugeBall.GetComponent<Renderer>();
    }
    private void Update()
    {
      
        if (mobile2vr.mobileToVRCl.CurseDetection()!=-1)
        InstantiateCurseEffect();
        if(gaugeBallMaterial.material.GetFloat("_Cutoff")==0)
        {
            villagePranked = true;
        }
        if(gaugeBallMaterial.material.GetFloat("_Cutoff")<=0)
        {
            villageHalfPranked = true;
        }
    }
    void InstantiateCurseEffect()
    {
        if (mobile2vr.mobileToVRCl.CurseDetection() == 0)
        {

            Instantiate(curseEffectSystem, curseableHouses[0].transform.position, Quaternion.identity);
            if (particleSystemForVillageStatus.activeInHierarchy != true)
            {
                particleSystemForVillageStatus.SetActive(true);
                particleLights.SetActive(true);
             
            }
            float fillAmount = gaugeBallMaterial.material.GetFloat("_Cutoff") - 0.25f;
            gaugeBallMaterial.material.SetFloat("_Cutoff", fillAmount);
            Trail_One.SetActive(true);
        }
        else if (mobile2vr.mobileToVRCl.CurseDetection() == 1)
        {

            Instantiate(curseEffectSystem, curseableHouses[1].transform.position, Quaternion.identity);
            if (particleSystemForVillageStatus.activeInHierarchy != true)
            {
                particleSystemForVillageStatus.SetActive(true);
                particleLights.SetActive(true);
            }
            float fillAmount = gaugeBallMaterial.material.GetFloat("_Cutoff") - 0.25f;
            gaugeBallMaterial.material.SetFloat("_Cutoff", fillAmount);
            Trail_Two.SetActive(true);
        }
        else if (mobile2vr.mobileToVRCl.CurseDetection() == 2)
        {
            
            Instantiate(curseEffectSystem, curseableHouses[2].transform.position, Quaternion.identity);
            if (particleSystemForVillageStatus.activeInHierarchy != true)
            {
                particleSystemForVillageStatus.SetActive(true);
                particleLights.SetActive(true);
            }
            float fillAmount = gaugeBallMaterial.material.GetFloat("_Cutoff") - 0.25f;
            gaugeBallMaterial.material.SetFloat("_Cutoff", fillAmount);
            Trail_Three.SetActive(true);
        }
        else if (mobile2vr.mobileToVRCl.CurseDetection() == 3)
        {

            Instantiate(curseEffectSystem, curseableHouses[3].transform.position, Quaternion.identity);
            if (particleSystemForVillageStatus.activeInHierarchy != true)
            {
                particleSystemForVillageStatus.SetActive(true);
                particleLights.SetActive(true);
            }
            float fillAmount = gaugeBallMaterial.material.GetFloat("_Cutoff") - 0.25f;
            gaugeBallMaterial.material.SetFloat("_Cutoff", fillAmount);
            Trail_Four.SetActive(true);
        }
    }
}
