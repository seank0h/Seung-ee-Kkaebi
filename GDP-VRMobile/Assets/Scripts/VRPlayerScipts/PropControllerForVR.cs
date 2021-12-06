using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropControllerForVR : MonoBehaviour
{
    public GameObject playerMeshEntity;
    private SkinnedMeshRenderer playerMesh;
    public GameObject playerPropMeshEntity;
    private MeshFilter playerPropMesh;
    private Renderer playerPropRenderer;
    int prevPropState;

    public GameObject prop1;
    public GameObject prop2;
    public GameObject prop3;
    public GameObject prop4;
    public GameObject prop5;
    public GameObject prop6;
    public GameObject prop7;


    private MeshFilter prop1Mesh;
    private Renderer prop1Renderer;
    private MeshFilter prop2Mesh;
    private Renderer prop2Renderer;
    private MeshFilter prop3Mesh;
    private Renderer prop3Renderer;
    private MeshFilter prop4Mesh;
    private Renderer prop4Renderer;
    private MeshFilter prop5Mesh;
    private Renderer prop5Renderer;
    private MeshFilter prop6Mesh;
    private Renderer prop6Renderer;
    private MeshFilter prop7Mesh;
    private Renderer prop7Renderer;

    public int propState;
    void Start()
    {
        playerMesh = playerMeshEntity.GetComponent<SkinnedMeshRenderer>();
        playerPropMesh = playerPropMeshEntity.GetComponent<MeshFilter>();
        playerPropRenderer = playerPropMeshEntity.GetComponent<Renderer>();

        prop1Mesh = prop1.GetComponent<MeshFilter>();
        prop1Renderer = prop1Mesh.GetComponent<Renderer>();

        prop2Mesh = prop2.GetComponent<MeshFilter>();
        prop2Renderer = prop2.GetComponent<Renderer>();

        prop3Mesh = prop3.GetComponent<MeshFilter>();
        prop3Renderer = prop3.GetComponent<Renderer>();

        prop4Mesh = prop4.GetComponent<MeshFilter>();
        prop4Renderer = prop4.GetComponent<Renderer>();

        prop5Mesh = prop5.GetComponent<MeshFilter>();
        prop5Renderer = prop5.GetComponent<Renderer>();

        prop6Mesh = prop6.GetComponent<MeshFilter>();
        prop6Renderer = prop6.GetComponent<Renderer>();

        prop7Mesh = prop7.GetComponent<MeshFilter>();
        prop7Renderer = prop7.GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        GetPropChange();
        
    }
    void GetPropChange()
    {
        prevPropState = propState;
        propState = mobile2vr.mobileToVRCl.GetPropState();
        if (prevPropState != propState)
        {
            ChangePlayerModel();
        }
    }
    public void ChangePlayerModel()
    {
        
        if(propState==0)
        {
            playerMeshEntity.SetActive(true);
            playerPropMesh.gameObject.SetActive(false);
        }
        else if(propState==1)
        {
            playerMeshEntity.SetActive(false);
            playerPropMesh.mesh = prop1Mesh.mesh;
            playerPropRenderer.material = prop1Renderer.material;
            playerPropMesh.gameObject.SetActive(true);
        }
        else if (propState == 2)
        {
            playerMeshEntity.SetActive(false);
            playerPropMesh.mesh = prop2Mesh.mesh;
            playerPropRenderer.material = prop2Renderer.material;
            playerPropMesh.gameObject.SetActive(true);
        }
        else if (propState == 3)
        {
            playerMeshEntity.SetActive(false);
            playerPropMesh.mesh = prop3Mesh.mesh;
            playerPropRenderer.material = prop3Renderer.material;
            playerPropMesh.gameObject.SetActive(true);
        }
        else if (propState == 4)
        {
            playerMeshEntity.SetActive(false);
            playerPropMesh.mesh = prop4Mesh.mesh;
            playerPropRenderer.material = prop4Renderer.material;
            playerPropMesh.gameObject.SetActive(true);
        }
        else if (propState == 5)
        {
            playerMeshEntity.SetActive(false);
            playerPropMesh.mesh = prop5Mesh.mesh;
            playerPropRenderer.material = prop5Renderer.material;
            playerPropMesh.gameObject.SetActive(true);
        }
        else if (propState == 6)
        {
            playerMeshEntity.SetActive(false);
            playerPropMesh.mesh = prop6Mesh.mesh;
            playerPropRenderer.material = prop6Renderer.material;
            playerPropMesh.gameObject.SetActive(true);
        }
        else if (propState == 7)
        {
            playerMeshEntity.SetActive(false);
            playerPropMesh.mesh = prop7Mesh.mesh;
            playerPropRenderer.material = prop7Renderer.material;
            playerPropMesh.gameObject.SetActive(true);
        }

    }
}
