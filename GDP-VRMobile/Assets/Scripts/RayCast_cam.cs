using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.EventSystems;


public class RayCast_cam : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    RaycastHit hit;
    Vector3 height = new Vector3(0, 0, 0);
    bool c_reset = false;
    Behaviour c_halo;
    bool n_reset = false;
    Behaviour n_halo;
    bool p_reset = false;
    Behaviour p_halo;
    private bool isBtnDown = false;

    public GameObject playerMeshEntity;
    public GameObject playerPropMeshEntity;
    private MeshFilter playerPropMesh;
    private Renderer playerPropRenderer;
    private Collider playerCollider;
    private SkinnedMeshRenderer playerMesh;
    public GameObject cameraRoot;
    public bool changeBack;
    public bool swapToProp;
    public bool proped = false;
    float prop_time = 0f;
    string mesh_name;
    int mesh_num;
    string prop_name = "";

    CurseManage curse = null;
    PlayerAlart pa = null;

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
        Dance();
        dust();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isBtnDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isBtnDown = false;
    }

    public void Dance()
    {
        if (!proped) {
            if (Physics.Raycast(gameObject.transform.position + height, gameObject.transform.forward, out hit, 1000))
            {
                Debug.DrawRay(gameObject.transform.position + height, gameObject.transform.forward * 1000, Color.red);
                if (hit.collider.tag == "Interactive") //건물 저주
                {
                    if (n_reset)
                    {
                        n_halo.enabled = false;
                        n_reset = false;
                        pa.sturning = false;
                    }
                    if (p_reset)
                    {
                        p_halo.enabled = false;
                        p_reset = false;
                    }

                    if (hit.distance <= 3.0f)
                    {
                        Debug.DrawRay(gameObject.transform.position + height, gameObject.transform.forward * 1000, Color.yellow);
                        c_halo = (Behaviour)hit.transform.gameObject.GetComponent("Halo");
                        c_halo.enabled = true;
                        c_reset = true;
                        if (Input.GetKey("q") || isBtnDown)
                        {
                            Debug.DrawRay(gameObject.transform.position + height, gameObject.transform.forward * 1000, Color.blue);
                            curse = hit.collider.gameObject.GetComponent<CurseManage>();
                            curse.cursing = true;
                        }
                    }
                    return;
                }
                else if (hit.collider.tag == "NPC") // npc 스턴
                {
                    if (c_reset)
                    {
                        curse.cursing = false;
                        c_halo.enabled = false;
                        c_reset = false;
                    }
                    if (p_reset)
                    {
                        p_halo.enabled = false;
                        p_reset = false;
                    }
                    //Debug.Log(hit.collider.name + " : " + hit.distance);
                    if (hit.distance <= 3.0f)
                    {
                        Debug.DrawRay(gameObject.transform.position + height, gameObject.transform.forward * 1000, Color.yellow);
                        n_halo = (Behaviour)hit.transform.gameObject.GetComponent("Halo");
                        n_halo.enabled = true;
                        n_reset = true;
                        if (Input.GetKey("q") || isBtnDown)
                        {
                            Debug.DrawRay(gameObject.transform.position + height, gameObject.transform.forward * 1000, Color.blue);
                            pa = hit.collider.gameObject.GetComponent<PlayerAlart>();
                            pa.sturning = true;
                        }
                    }
                    return;
                }
                else if (hit.collider.tag == "Prop")
                {
                    /*
                    if (prop_name != hit.collider.name)
                    {
                        p_halo.enabled = false;
                        p_reset = false;
                    }
                    prop_name = hit.collider.name;*/
                    if (c_reset)
                    {
                        curse.cursing = false;
                        c_halo.enabled = false;
                        c_reset = false;
                    }
                    if (n_reset)
                    {
                        n_halo.enabled = false;
                        n_reset = false;
                        pa.sturning = false;
                    }
                    if (hit.distance <= 3.0f)
                    {
                        Debug.DrawRay(gameObject.transform.position + height, gameObject.transform.forward * 1000, Color.yellow);
                        p_halo = (Behaviour)hit.transform.gameObject.GetComponent("Halo");
                        p_halo.enabled = true;
                        p_reset = true;
                        mesh_name = hit.collider.GetComponent<MeshFilter>().mesh.name;

                        if (Input.GetKeyDown("q") || isBtnDown)
                        {
                            if (mesh_name == "ChoppingBlock_01 Instance")
                            {
                                mesh_num = 1;
                            }
                            else if (mesh_name == "FireWoodPile_01 Instance")
                            {
                                mesh_num = 2;
                            }
                            else if (mesh_name == "WheelBarrow_01 Instance")
                            {
                                mesh_num = 3;
                            }
                            else if (mesh_name == "Trough_01 Instance")
                            {
                                mesh_num = 4;
                            }
                            else if (mesh_name == "Box_ Instance")
                            {
                                mesh_num = 5;
                            }
                            else if (mesh_name == "BoxC_ Instance")
                            {
                                mesh_num = 6;
                            }
                            else if (mesh_name == "Ghamhany_ Instance")
                            {
                                mesh_num = 7;
                            }
                            mobileClient.cl.setProp(mesh_num);

                            Debug.Log("mesh_name : " + mesh_num);
                            ChangeModelAttempt(hit.collider.gameObject);
                            proped = true;
                        }
                    }
                    return;
                }
                else
                {
                    if (c_reset)
                    {
                        curse.cursing = false;
                        c_halo.enabled = false;
                        c_reset = false;
                    }
                    if (n_reset)
                    {
                        n_halo.enabled = false;
                        n_reset = false;
                        pa.sturning = false;
                    }
                    if (p_reset)
                    {
                        p_halo.enabled = false;
                        p_reset = false;
                    }
                }
            }
            else
            {
                curse.cursing = false;
                pa.sturning = false;
            }
        } else
        {
            // Debug.Log("prop true");
            if (c_reset)
            {
                curse.cursing = false;
                c_halo.enabled = false;
                c_reset = false;
            }
            if (n_reset)
            {
                n_halo.enabled = false;
                n_reset = false;
                pa.sturning = false;
            }
            if (p_reset)
            {
                p_halo.enabled = false;
                p_reset = false;
            }

            prop_time += Time.deltaTime;

            // curse.cursing = false;
            // pa.sturning = false;

            if (prop_time>=10 || (Input.GetKeyDown("q") || isBtnDown))
            {
                // Debug.Log("model swap");
                prop_time = 0;
                mobileClient.cl.setProp(0);
                ModelSwap();
                proped = false;
            }
        }

    }

    public void ChangeModelAttempt(GameObject prop)
    {
        GameObject gameObjectHit;
        playerPropMesh.gameObject.SetActive(true);
        Debug.Log("Raycast hit Prop");
        gameObjectHit = prop;
        playerPropMesh.mesh = gameObjectHit.GetComponent<MeshFilter>().mesh;
        Renderer hitPropMat = gameObjectHit.GetComponent<Renderer>();
        playerPropRenderer.material = hitPropMat.material;

        playerMesh.gameObject.SetActive(false);
        swapToProp = true;
    }
    public void ModelSwap()
    {
        playerPropMesh.gameObject.SetActive(false);
        playerMesh.gameObject.SetActive(true);
        playerMesh.transform.localScale = new Vector3(1f, 1f, 1f);
        changeBack = false;
    }

    public void dust()
    {
        if (Input.GetKeyDown("e"))
        {
            Debug.Log("dust on");
            mobileClient.cl.setDustStrom(1);
        }
        else if (Input.GetKeyDown("r"))
        {
            Debug.Log("dust off");
            mobileClient.cl.setDustStrom(0);
        }
    }
}
    