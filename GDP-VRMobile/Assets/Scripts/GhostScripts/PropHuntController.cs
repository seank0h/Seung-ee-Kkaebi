using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StarterAssets
{ 
public class PropHuntController : MonoBehaviour
{
        public GameObject playerMeshEntity;
        public GameObject playerPropMeshEntity;
        private MeshFilter playerPropMesh;
        private Renderer playerPropRenderer;
        private Collider playerCollider;
    private SkinnedMeshRenderer playerMesh;
    private SkinnedMeshRenderer originalPlayerMesh;
    public GameObject cameraRoot;
        public bool changeBack;
        public bool swapToProp;
        // Start is called before the first frame update
        void Start()
    {
            playerMesh = playerMeshEntity.GetComponent<SkinnedMeshRenderer>();
            playerCollider = playerMeshEntity.GetComponent<CapsuleCollider>();
            playerPropMesh = playerPropMeshEntity.GetComponent<MeshFilter>();
            playerPropRenderer = playerPropMeshEntity.GetComponent<Renderer>();
        }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerPropMesh.mesh);
        ChangeModelAttempt();
        ModelSwap();
    }

    public void ChangeModelAttempt()
    {
            if(Input.GetKeyDown(KeyCode.E))
            {
                RaycastHit hit;
                GameObject gameObjectHit;
                if (Physics.Raycast(cameraRoot.transform.position, cameraRoot.transform.TransformDirection(Vector3.forward), out hit, 10f))
                {
                    
                    Debug.DrawRay(cameraRoot.transform.position, cameraRoot.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    Debug.Log("Raycast hit");
                    if (hit.transform.gameObject.tag == "Prop")
                    {
                        if (changeBack)
                            playerPropMesh.gameObject.SetActive(true);
                        Debug.Log("Raycast hit Prop");
                        gameObjectHit = hit.transform.gameObject;
                        playerPropMesh.mesh = gameObjectHit.GetComponent<MeshFilter>().mesh;
                        Renderer hitPropMat = gameObjectHit.GetComponent<Renderer>();
                        playerPropRenderer.material = hitPropMat.material;

                        playerMesh.gameObject.SetActive(false);
                        swapToProp = true;
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
            if (Input.GetKeyDown(KeyCode.Q))
            {
                playerPropMesh.gameObject.SetActive(false);
                playerMesh.gameObject.SetActive(true);
                playerMesh.transform.localScale = new Vector3(1f, 1f, 1f);
                changeBack = false;
            }
        }
}
}
