using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRPlayerTeleport : MonoBehaviour
{
	public GameObject vrPlayerEntity;
    public float yPositionCalibration;
    TeleportToggle vrPlayerTeleport;
    private AudioSource teleportAudio;
 
    void Start()
    {
	    vrPlayerTeleport = vrPlayerEntity.GetComponent<TeleportToggle>();
        //yPositionCalibration = vrPlayerEntity.transform.position.y;
        //this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x,3.43F, this.gameObject.transform.position.z);
        teleportAudio = GetComponent<AudioSource>();
    }

    void Update() {
        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name =="Teleport_L")
        {
			//Debug.Log("Touched Left Teleport");
			vrPlayerTeleport.ButtonTeleport(true); // teleport to Left
            teleportAudio.Play();
        }
		if(other.gameObject.name =="Teleport_R")
        {
			//Debug.Log("Touched Right Teleport");
			vrPlayerTeleport.ButtonTeleport(false); // teleport to Right
            teleportAudio.Play();
		}
    }

    private void OnTriggerStay(Collider other) {
        DustStormRemover.dsr.setTrigger(true, other);
    }

    private void OnTriggerExit(Collider other) {
        DustStormRemover.dsr.disableTrigger(false);
    }
}
