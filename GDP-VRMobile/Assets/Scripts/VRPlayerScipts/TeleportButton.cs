using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportButton : MonoBehaviour
{
    GameObject characterController;
    public GameObject[] teleportPositions;
    public Transform[] teleportInteractablePositions;
    public GameObject teleportInteractable;
    public int teleportIndex;
    public int currIndex;
    public float teleportThresholdtimer;

    public bool hitButton;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        
    }
    public void ButtonTeleport(bool direction)
    {
        //false = left, true = right
        if(hitButton)
        {
            if (direction)
            {
                if (currIndex == 3)
                {
                    teleportIndex = 0;
                }
                else
                    teleportIndex++;
            }
            if (direction == false)
            {
                if (currIndex == 0)
                {
                    teleportIndex = teleportPositions.Length - 1;
                }
                else
                    teleportIndex--;
            }
            DoTeleport();
        }
        hitButton = false;
    

       

    }
    public void DoTeleport()
    {
        var character = characterController;
        var characterTransform = character.transform;
        var destTransform = teleportPositions[teleportIndex];

        Vector3 destPosition = destTransform.transform.position;
        //destPosition.y += character.transform.position.y * 0.5f;
        Quaternion destRotation = teleportPositions[teleportIndex].transform.rotation;// destTransform.rotation;
        BlinkTransition();
        this.gameObject.transform.position = destPosition;
        this.gameObject.transform.rotation = destRotation;
        teleportThresholdtimer = 1.0f;
    }
    public void BlinkTransition()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.name=="LeftTeleport")
        {
            if (other.gameObject.name == "OVRHandPrefab_L")
            {
                ButtonTeleport(false);
                hitButton = true;
            }
        }
        if (this.gameObject.name == "RightTeleport")
        {
            if (other.gameObject.tag == "OVRHandPrefab_R")
            {
                ButtonTeleport(true);
                hitButton = true;
            }
        }
        
    }
}
