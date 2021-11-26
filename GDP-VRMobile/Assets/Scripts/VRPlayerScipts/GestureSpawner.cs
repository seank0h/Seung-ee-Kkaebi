using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureSpawner : MonoBehaviour
{
    [Header("SpawnTransform")]
    // Transform where the bat have to be Instantiated
    public Transform hand;

    [Header("BulletPrefab")]
    // GameObject used as bat to Instantiate
    public GameObject bat;

    public float batDuration;
    public float batCooldown = 0;
    bool ifBat;
    bool beginCooldown;

    private void Update()
    {
        if(ifBat)
        {
            batDuration -= Time.deltaTime;
            if(batDuration<=0)
            {
                bat.SetActive(false);
                batDuration = 5.0f;
                ifBat = false;
                batCooldown = 5.0f;
                beginCooldown = true;
            }
        }
        if(beginCooldown)
        {
            batCooldown -= Time.deltaTime;
        }
    }
    public void OnActivate(){
        Debug.Log("BAT is activated!!!"); bat.SetActive(true);
        ifBat = true;
        if (batCooldown<=0)
        {
            
        }
       
    }
    public void Inactivate(){
        Debug.Log("BAT is inactivated***");
        //bat.SetActive(false);
    }
}
