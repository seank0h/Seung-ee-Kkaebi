using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseVisualizer : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> curseableHouses;
    public GameObject curseEffectSystem;
    GameStateManager gameManager;
   
    void Start()
    {
        gameManager = this.GetComponent<GameStateManager>();
    }
    private void Update()
    {
        if(mobile2vr.mobileToVRCl.CurseDetection()!=-1)
        InstantiateCurseEffect();
    }
    void InstantiateCurseEffect()
    {
        if(mobile2vr.mobileToVRCl.CurseDetection()==0)
        {
            Instantiate(curseEffectSystem, curseableHouses[0].transform.position, Quaternion.identity);
            gameManager.IncrementProgress(0.25f);
        }
        else if (mobile2vr.mobileToVRCl.CurseDetection() == 1)
        {
            Instantiate(curseEffectSystem, curseableHouses[1].transform.position, Quaternion.identity);
            gameManager.IncrementProgress(0.25f);
        }
        else if(mobile2vr.mobileToVRCl.CurseDetection() == 2)
        {
            Instantiate(curseEffectSystem, curseableHouses[2].transform.position, Quaternion.identity);
            gameManager.IncrementProgress(0.25f);
        }
        else if(mobile2vr.mobileToVRCl.CurseDetection() == 3)
            Instantiate(curseEffectSystem, curseableHouses[3].transform.position, Quaternion.identity);
            gameManager.IncrementProgress(0.25f);


    }
}
