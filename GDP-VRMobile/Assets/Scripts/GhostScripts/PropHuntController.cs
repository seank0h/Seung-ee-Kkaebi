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
        private MeshFilter playerMesh;
        private MeshFilter originalPlayerMesh;
        public GameObject cameraRoot;
    // Start is called before the first frame update
    void Start()
    {
            playerMesh = playerMeshEntity.GetComponent<MeshFilter>();
            originalPlayerMesh = playerMeshMem.GetComponent<MeshFilter>();
            Debug.Log(originalPlayerMesh.mesh);
        _input = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
            Debug.Log(originalPlayerMesh.mesh);
            ChangeModelAttempt();
            ModelSwap();
    }

    private void ChangeModelAttempt()
    {
            
        if(_input.swap)
        {
                Debug.Log("Got to pressing E");
                RaycastHit hit;
                GameObject gameObjectHit;
                LayerMask propMask = 8;
            if(Physics.Raycast(cameraRoot.transform.position, cameraRoot.transform.TransformDirection(Vector3.forward), out hit, 10f))
                {
                    Debug.DrawRay(cameraRoot.transform.position, cameraRoot.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    Debug.Log("Raycast hit");
                    if(hit.transform.gameObject.tag=="Prop")
                    {
                        Debug.Log("Raycast hit Prop");
                        gameObjectHit = hit.transform.gameObject;
                        playerMesh.mesh = gameObjectHit.GetComponent<MeshFilter>().mesh;
                        //Just a temporary fix because the scale of the objects are so big, hopefully wont be necessary for actual props
                        playerMesh.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                        _input.swap = false;
                    }
                    
                    
                }
                else
                {
                    Debug.Log(originalPlayerMesh.mesh);
                    Debug.DrawRay(cameraRoot.transform.position, cameraRoot.transform.TransformDirection(Vector3.forward) * 1000, Color.black);
                    //Debug.Log("Did not Hit");
                }
            }
       

    }
    private void ModelSwap()
        {
            if (_input.changeBack)
            {
                Debug.Log(originalPlayerMesh.mesh);
                playerMesh.mesh = originalPlayerMesh.mesh;
                playerMesh.transform.localScale = new Vector3(1f, 1f, 1f);
                _input.changeBack = false;
            }
        }
}
}
