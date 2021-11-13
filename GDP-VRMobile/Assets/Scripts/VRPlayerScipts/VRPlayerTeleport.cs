using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRPlayerTeleport : MonoBehaviour
{
	public GameObject vrPlayerEntity;
    public float yPositionCalibration;
    TeleportToggle vrPlayerTeleport;
 [SerializeField]
    private Material activeMat;
    [SerializeField]
    private Material holdMat;
    [SerializeField]
    private Material inactiveMat;
    void Start()
    {
		
	    vrPlayerTeleport = vrPlayerEntity.GetComponent<TeleportToggle>();
         yPositionCalibration = vrPlayerEntity.transform.position.y;
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x,3.43F, this.gameObject.transform.position.z);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name =="Teleport_L")
        {
			Debug.Log("Touched Left Teleport");
		
			vrPlayerTeleport.ButtonTeleport(false); // teleport to Left
        }
		if(other.gameObject.name =="Teleport_R")
        {
			Debug.Log("Touched Right Teleport");
			vrPlayerTeleport.ButtonTeleport(true); // teleport to Right
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
