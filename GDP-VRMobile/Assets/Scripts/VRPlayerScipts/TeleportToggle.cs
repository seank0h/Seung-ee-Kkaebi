using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportToggle : MonoBehaviour
{    
    public GameObject characterController;
	public GameObject[] teleportPositions;
	public Transform[] teleportInteractablePositions;
	public int teleportIndex;
	public int currIndex;

   public bool teleportDelay;
   public float teleportTimer;

    [Header("Fade Screen")]
    public Image blackScreen;

    public bool teleportLock;

    
    void Start()
    {
		characterController = this.gameObject;
		teleportIndex = 0;
		currIndex = 0;


	}

    // Update is called once per frame
    void Update()
    {
        if(teleportDelay)
        {
            teleportTimer-=Time.deltaTime;
        }
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
        if(teleportTimer<=0)
        {
            Debug.Log("cAME TO teleport");
            character.transform.position = destPosition;
		    character.transform.rotation = destRotation;
            teleportTimer=1.0f;
            teleportDelay = false;
        }
		
       
	}
	public void BlinkTransition()
    {
        teleportDelay = true;
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
                currIndex = teleportIndex;
			}
			else
            {
                teleportIndex++;
                currIndex = teleportIndex;
            }
				
		}
		if (direction==false)
        {
			if (currIndex == 0)
			{
				teleportIndex = teleportPositions.Length - 1;
                 currIndex = teleportIndex;
			}
			else
            {
                teleportIndex--;
                currIndex = teleportIndex;
            }
				
		}
		DoTeleport();

	}
}
