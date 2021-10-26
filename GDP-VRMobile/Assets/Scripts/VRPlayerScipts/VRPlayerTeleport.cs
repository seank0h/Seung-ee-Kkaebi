using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayerTeleport : MonoBehaviour
{
	GameObject characterController;
	GameObject[] teleportPositions;
	Transform[] teleportInteractablePositions;
	GameObject teleportInteractable;
	public int teleportIndex;
	public int currIndex;
	public float teleportThresholdtimer;
    // Start is called before the first frame update

    void Start()
    {
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
		if(teleportInteractable.transform.rotation.y>0 && teleportThresholdtimer>0)
        {
			teleportIndex++;
			
        }
		if (teleportInteractable.transform.rotation.y < 0 && teleportThresholdtimer > 0)
		{
			if (currIndex == 0)
			{
				teleportIndex = teleportPositions.Length - 1;
			}
			else
				teleportIndex--;
		}
		currIndex = teleportIndex;
		ResetRotation();
		if(teleportThresholdtimer<0)
        {
			DoTeleport();
			MoveTeleportationInteractable();
        }
		teleportThresholdtimer = 1.0f;

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
		characterTransform.position = destPosition;
		characterTransform.rotation = destRotation;
	}
	public void BlinkTransition()
    {

    }
	public void ResetRotation()
    {
		teleportInteractable.transform.eulerAngles = new Vector3(0, 0, 0);
    }
	public void MoveTeleportationInteractable()
    {
		teleportInteractable.transform.position = teleportInteractablePositions[teleportIndex].transform.position;
    }
}
