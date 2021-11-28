using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportToggle : MonoBehaviour
{    
    public GameObject characterController;
	public GameObject[] teleportPositions;
	public int teleportIndex;
	public int currIndex;
    public Image fadeScreen;
    public bool teleportLock;

    private GameObject trigger_L,trigger_R;
    
    [SerializeField]
    private Material activeMat;
    [SerializeField]
    private Material holdMat;
    [SerializeField]
    private Material inactiveMat;
    
    void Start()
    {
		characterController = this.gameObject;
		teleportIndex = 0;
		currIndex = 0;

        trigger_L = GameObject.Find("Teleport_L");
        trigger_R = GameObject.Find("Teleport_R");
	}

    public void ButtonTeleport(bool direction)
    {
		trigger_L.GetComponent<SphereCollider>().isTrigger = false;
        trigger_R.GetComponent<SphereCollider>().isTrigger = false;

        //true = left, false = right
		if (direction == true && teleportLock == false){
            trigger_L.GetComponent<MeshRenderer>().material = holdMat;
			if (currIndex == 3){
				teleportIndex = 0;
                currIndex = teleportIndex;
			}else{
                teleportIndex++;
                currIndex = teleportIndex;
            }	
		}if (direction == false && teleportLock == false){
            trigger_R.GetComponent<MeshRenderer>().material = holdMat;
			if (currIndex == 0){
				teleportIndex = teleportPositions.Length - 1;
                currIndex = teleportIndex;
			}else{
                teleportIndex--;
                currIndex = teleportIndex;
            }
		}
		StartCoroutine(FadeInOut());
	}

    private IEnumerator FadeInOut(){
        // Make sure teleport can't be called again
        teleportLock = true;
            
        // Reset Time counter variable
        float currentTime = 0;
        // Loop until counter is done
        while (currentTime < 1)
        {
            // Fade out screen
            fadeScreen.color = Color.Lerp(Color.clear, Color.black, currentTime);
            // Wait one frame
            yield return null;
            // Increment Timer
            currentTime += Time.deltaTime * 2;
        }
        // Set full black screen
        fadeScreen.color = Color.black;
        
        // TELEPORT HERE
        var character = characterController;
		var characterTransform = character.transform;
		var destTransform = teleportPositions[teleportIndex];

		Vector3 destPosition = destTransform.transform.position;
		//destPosition.y += character.transform.position.y * 0.5f;
		Quaternion destRotation = teleportPositions[teleportIndex].transform.rotation;// destTransform.rotation;
		
        Debug.Log("TELEPORT TO : " + teleportPositions[teleportIndex]);
        character.transform.position = destPosition;
		character.transform.rotation = destRotation;
        
        // Wait one second
        yield return new WaitForSeconds(0.1f);
        // Reset timer again
        currentTime = 0;
        // Loop until timer is done again
        while (currentTime < 1)
        {
            // Fade in screen
            fadeScreen.color = Color.Lerp(Color.black, Color.clear, currentTime);
             
            // Wait one frame
            yield return null;
            // Increment Timer
            currentTime += Time.deltaTime * 2;
        }
        // Allow teleporting again
        teleportLock = false;

        trigger_L.GetComponent<MeshRenderer>().material = inactiveMat;
        trigger_R.GetComponent<MeshRenderer>().material = inactiveMat;
        trigger_L.GetComponent<SphereCollider>().isTrigger = true;
        trigger_R.GetComponent<SphereCollider>().isTrigger = true;
    }
	
}
