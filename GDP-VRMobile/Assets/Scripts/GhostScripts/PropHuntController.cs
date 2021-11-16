using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StarterAssets
{ 
public class PropHuntController : MonoBehaviour
{
    private StarterAssetsInputs _input;
    public GameObject playerMeshEntity;
    public GameObject playerMeshMem;
    private Collider playerCollider;
    private SkinnedMeshRenderer playerMesh;
    private SkinnedMeshRenderer originalPlayerMesh;
    public GameObject cameraRoot;
    // Start is called before the first frame update
    void Start()
    {
        playerMesh = playerMeshEntity.GetComponent<SkinnedMeshRenderer>();
        originalPlayerMesh = playerMeshMem.GetComponent<SkinnedMeshRenderer>();
        playerCollider = playerMeshEntity.GetComponent<CapsuleCollider>();
        Debug.Log(originalPlayerMesh.sharedMesh);
        _input = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(originalPlayerMesh.sharedMesh);
        ChangeModelAttempt();
        ModelSwap();
    }

    public void ChangeModelAttempt()
    {
            if(Input.GetKeyDown(KeyCode.F))
            {
                RaycastHit hit;
                GameObject gameObjectHit;
                if (Physics.Raycast(cameraRoot.transform.position, cameraRoot.transform.TransformDirection(Vector3.forward), out hit, 10f))
                {
                    Debug.DrawRay(cameraRoot.transform.position, cameraRoot.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    Debug.Log("Raycast hit");
                    if (hit.transform.gameObject.tag == "Prop")
                    {
                        Debug.Log("Raycast hit Prop");
                        gameObjectHit = hit.transform.gameObject;
                        playerMesh.sharedMesh = gameObjectHit.GetComponent<MeshFilter>().sharedMesh;
                        //Just a temporary fix because the scale of the objects are so big, hopefully wont be necessary for actual props
                        //playerMesh.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                        _input.swap = false;
                    }


                }
                else
                {
                    Debug.Log(originalPlayerMesh.sharedMesh);
                    Debug.DrawRay(cameraRoot.transform.position, cameraRoot.transform.TransformDirection(Vector3.forward) * 1000, Color.black);
                    //Debug.Log("Did not Hit");
                }
            }
            
    }
        public void ModelSwap()
        {
            
                Debug.Log(originalPlayerMesh.sharedMesh);
                playerMesh.sharedMesh = originalPlayerMesh.sharedMesh;
                playerMesh.transform.localScale = new Vector3(1f, 1f, 1f);
                _input.changeBack = false;
            
        }
}
}
