using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropControllerForVR : MonoBehaviour
{
    public GameObject playerMeshEntity;
    private SkinnedMeshRenderer playerMesh;
    public GameObject prop1;
    public GameObject prop2;
    public GameObject prop3;
    public GameObject prop4;
    public GameObject prop5;
    public GameObject prop6;
    public GameObject prop7;


    private MeshFilter prop1Mesh;
    private Renderer propp1Renderer;
    private MeshFilter prop2Mesh;
    private Renderer propp2Renderer;
    private MeshFilter prop3Mesh;
    private Renderer propp3Renderer;
    private MeshFilter prop4Mesh;
    private Renderer propp4Renderer;
    private MeshFilter prop5Mesh;
    private Renderer propp5Renderer;
    private MeshFilter prop6Mesh;
    private Renderer propp6Renderer;
    private MeshFilter prop7Mesh;
    private Renderer propp7Renderer;

    public int propState;
    void Start()
    {
        playerMesh = playerMeshEntity.GetComponent<SkinnedMeshRenderer>();

        prop1Mesh = prop1.GetComponent<MeshFilter>();
        propp1Renderer = prop1Mesh.GetComponent<Renderer>();

        prop2Mesh = prop2.GetComponent<MeshFilter>();
        propp2Renderer = prop2Mesh.GetComponent<Renderer>();

        prop3Mesh = prop3.GetComponent<MeshFilter>();
        propp3Renderer = prop3Mesh.GetComponent<Renderer>();

        prop4Mesh = prop4.GetComponent<MeshFilter>();
        propp4Renderer = prop4Mesh.GetComponent<Renderer>();

        prop5Mesh = prop5.GetComponent<MeshFilter>();
        propp5Renderer = prop5Mesh.GetComponent<Renderer>();

        prop6Mesh = prop6.GetComponent<MeshFilter>();
        propp6Renderer = prop6Mesh.GetComponent<Renderer>();

        prop7Mesh = prop7.GetComponent<MeshFilter>();
        propp7Renderer = prop7Mesh.GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        GetPropChange();
    }
    void GetPropChange()
    {
        propState = mobile2vr.mobileToVRCl.GetPropState();
    }
    public void ChangePlayerModel()
    {
        if(propState==0)
        {

        }
        else if(propState==1)
        {

        }
        else if (propState == 2)
        {

        }
        else if (propState == 3)
        {

        }
        else if (propState == 4)
        {

        }
        else if (propState == 5)
        {

        }
        else if (propState == 6)
        {

        }
        else if (propState == 7)
        {

        }

    }
}
