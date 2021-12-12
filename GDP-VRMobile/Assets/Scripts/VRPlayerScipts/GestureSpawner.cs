using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureSpawner : MonoBehaviour
{
    [Header("SpawnTransform")]
    // Transform where the bat have to be Instantiated
    public Transform hand;
    public GameObject handRotation;

    [Header("Prefab To Instantiate")]
    // GameObject used as bat to Instantiate
    public GameObject bat;
    public GameObject currBat;

    public float batDuration;
    public float batCooldown = 0;
    bool ifBat=false;
    bool beginCooldown;
    bool showCooldown;
    private AudioSource batSpawnAudio;

    private void Start()
    {
        batSpawnAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(ifBat)
        {
            batDuration -= Time.deltaTime;
            
            if(batDuration<=0)
            {
                currBat.SetActive(false);
                batDuration = 7.0f;
                ifBat = false;
                batCooldown = 3.0f;
                beginCooldown = true;
            }
            
        }
        if (mobile2vr.mobileToVRCl.dustStormState == true && ifBat)
            Inactivate();

        if(beginCooldown)
        {
            batCooldown -= Time.deltaTime;
            if (showCooldown==false)
            {
                BatRadialProgress.rp.start = true;
                showCooldown = true;
            }
           
            if (batCooldown <= 0)
            {
                beginCooldown = false;
                showCooldown = false;
            }
        }
      
    }
    public void OnActivate(){
        //Move to bat code and play on awake so its only once
        if (batCooldown <= 0&&VRDustParticleEffect.VRdpe.effectOn == false && ifBat==false)
        {
            ifBat = true;
            currBat.SetActive(true);
            batSpawnAudio.Play();
            batCooldown = 3.0f;
        }
       
    }
    public void Inactivate(){
        currBat.SetActive(false);
        ifBat = false;
        batCooldown = 3.0f;
        beginCooldown = true;
    }
}
