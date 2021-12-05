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
    bool ifBat;
    bool beginCooldown;

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
                batDuration = 5.0f;
                ifBat = false;
                batCooldown = 3.0f;
                beginCooldown = true;
            }
            
        }
        if(beginCooldown)
        {
            batCooldown -= Time.deltaTime;
        }
    }
    public void OnActivate(){
        Debug.Log("BAT is activated!!!");
        batSpawnAudio.Play();

        /*
        if(currBat==null)
        {
            Vector3 positionCalibration = new Vector3(hand.position.x + 3, hand.position.y, hand.position.z + 3);
            Vector3 rotationCalibration = new Vector3(30f, 0, 0);
            currBat = Instantiate(bat, positionCalibration, Quaternion.identity);
            currBat.transform.parent = hand.transform.parent;
            currBat.transform.eulerAngles = handRotation.transform.eulerAngles;
            //currBat.transform.eulerAngles = rotationCalibration; 
        }
        */
        if (batCooldown<=0)
        {
            ifBat = true;
            currBat.SetActive(true);
        }
       
    }
    public void Inactivate(){
        Debug.Log("BAT is inactivated***");
        //bat.SetActive(false);
    }
}
