using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	[SerializeField]
    private Material activeMat;
    [SerializeField]
    private Material holdMat;
    [SerializeField]
    private Material inactiveMat;

    [Header("Fade Screen")]
    public Image blackScreen;

    public bool teleportLock;

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
		StartCoroutine(FadeInOut());
    }

	private IEnumerator FadeInOut()
    {
        // Make sure teleport can't be called again
        teleportLock = true;
            
        // Reset Time counter variable
        float currentTime = 0;
        // Loop until counter is done
        while (currentTime < 1)
        {
            // Fade out screen
            blackScreen.color = Color.Lerp(Color.clear, Color.black, currentTime);
            // Wait one frame
            yield return null;
            // Increment Timer
            currentTime += Time.deltaTime;
        }
        // Set full black screen
        blackScreen.color = Color.black;
            
        // Wait one second
        yield return new WaitForSeconds(0.1f);
        // Reset timer again
        currentTime = 0;
        // Loop until timer is done again
        while (currentTime < 1)
        {
            // Fade in screen
            blackScreen.color = Color.Lerp(Color.black, Color.clear, currentTime);
            // Wait one frame
            yield return null;
            // Increment Timer
            currentTime += Time.deltaTime;
        }
        // Allow teleporting again
        teleportLock = false;
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name =="OVRHandPrefab_L" && other.gameObject.name =="OVRHandPrefab_R" && other.GetComponent<BoneTriggerLogic>() != null)
        {
			GetComponent<MeshRenderer>().material = holdMat;
			ButtonTeleport(false); // teleport to Right
        }
		if(other.gameObject.name =="OVRHandPrefab_L" && other.gameObject.name =="OVRHandPrefab_R" && other.GetComponent<BoneTriggerLogic>() != null)
        {
			GetComponent<MeshRenderer>().material = holdMat;
			ButtonTeleport(true); // teleport to Left
		}
    }
	private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<BoneTriggerLogic>() != null)
        {
            GetComponent<MeshRenderer>().material = inactiveMat;
        }
    }
}
