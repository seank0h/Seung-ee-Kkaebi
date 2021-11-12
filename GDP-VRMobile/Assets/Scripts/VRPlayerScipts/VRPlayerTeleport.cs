using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayerTeleport : MonoBehaviour
{
	GameObject characterController;
	public GameObject[] teleportPositions;
	public Transform[] teleportInteractablePositions;
	public GameObject teleportInteractable;
	public int teleportIndex;
	public int currIndex;
	public float teleportThresholdtimer;

	public GameObject leftButton;
	public GameObject rightButton;
    // Start is called before the first frame update

    void Start()
    {
		characterController = this.gameObject;
		teleportIndex = 0;
		currIndex = 0;
		teleportThresholdtimer = 1.0f;

	}

    // Update is called once per frame
    void Update()
    {
		UpdateTeleportPositions();
    }
	public void UpdateTeleportPositions()
    {
		if(teleportInteractable.transform.rotation.y!=0 && teleportThresholdtimer>0)
        {
			teleportThresholdtimer -= Time.deltaTime;
		}
		if(teleportInteractable.transform.rotation.y>0 && teleportThresholdtimer<0)
        {
			if (currIndex == 3)
			{
				teleportIndex = 0;
			}
			else
			teleportIndex++;
			
        }
		if (teleportInteractable.transform.rotation.y < 0 && teleportThresholdtimer < 0)
		{
			if (currIndex == 0)
			{
				teleportIndex = teleportPositions.Length - 1;
			}
			else
				teleportIndex--;
		}
		
		
		if(teleportThresholdtimer<0)
        {
			currIndex = teleportIndex;
			DoTeleport();
			MoveTeleportationInteractable();
        }
		

    }
	public void TeleportTimer()
	{
		
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
		ResetRotation();
		teleportThresholdtimer = 1.0f;
	}
	public void BlinkTransition()
    {

    }

	public void ButtonTeleport(bool direction)
    {
		//false = left, true = right
		if (direction)
		{
			if (currIndex == 3)
			{
				teleportIndex = 0;
			}
			else
				teleportIndex++;
		}
		if (direction==false)
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
	public void ResetRotation()
    {
		Debug.Log("Getting To Reset");
		teleportInteractable.transform.eulerAngles = new Vector3(0, 0, 0);
    }
	public void MoveTeleportationInteractable()
    {
		teleportInteractable.transform.position = teleportInteractablePositions[teleportIndex].transform.position;
    }

<<<<<<< Updated upstream
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name =="OVRHandPrefab_L" && other.gameObject.name =="OVRHandPrefab_R")
        {
			ButtonTeleport(false);
        }
		if(other.gameObject.name =="OVRHandPrefab_L" && other.gameObject.name =="OVRHandPrefab_R")
        {
			ButtonTeleport(true);
		}
    }
=======

>>>>>>> Stashed changes
}
