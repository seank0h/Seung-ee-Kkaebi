using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class RayCast_cam : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    RaycastHit hit;
    Vector3 height = new Vector3(0, 0, 0);
    bool c_reset = false;
    Behaviour c_halo = null;
    bool n_reset = false;
    Behaviour n_halo = null;
    bool p_reset = false;
    Behaviour p_halo = null;
    private bool isBtnDown = false;

    public GameObject playerMeshEntity;
    public GameObject playerPropMeshEntity;
    public Slider slider;
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
    bool prop_cool = false;
    bool dust_cool = false;

    CurseManage curse = null;
    PlayerAlart pa = null;

    public SkinnedMeshRenderer Drenderer;
    public Material ghostMaterialTransparent;
    public Material ghostMaterialRevealed;

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
        if (Input.GetKeyDown("o"))
        {
            mobileClient.cl.setPlayerMat(1);
        }
        if (Input.GetKeyDown("p"))
        {
            mobileClient.cl.setPlayerMat(0);
        }
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
        prop_cool = RadialProgress_Mobile.rp.isProgress();
        if (!proped) {
            if (Physics.Raycast(gameObject.transform.position + height, gameObject.transform.forward, out hit, 1000))
            {
                Debug.DrawRay(gameObject.transform.position + height, gameObject.transform.forward * 1000, Color.red);
                if (hit.collider.tag == "Interactive") //건물 저주
                {
                    if (slider.gameObject.activeSelf)
                        slider.gameObject.SetActive(false);
                    if (n_reset)
                    {
                        n_halo.enabled = false;
                        n_reset = false;
                        if (pa != null)
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
                        curse = hit.collider.gameObject.GetComponent<CurseManage>();
                        slider.gameObject.SetActive(true);
                        slider.value = curse.curse_time / 10 * 100;
                        c_halo = (Behaviour)hit.transform.gameObject.GetComponent("Halo");
                        c_halo.enabled = true;
                        c_reset = true;
                        if (Input.GetKey("q") || isBtnDown)
                        {
                            Debug.DrawRay(gameObject.transform.position + height, gameObject.transform.forward * 1000, Color.blue);
                            curse.cursing = true;

                        }
                    }
                    return;
                }
                else if (hit.collider.tag == "NPC") // npc 스턴
                {
                    if (slider.gameObject.activeSelf)
                        slider.gameObject.SetActive(false);
                    if (n_halo != null)
                    {
                        n_halo.enabled = false;
                        n_reset = false;
                    }
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
                        pa = hit.collider.gameObject.GetComponent<PlayerAlart>();
                        slider.gameObject.SetActive(true);
                        slider.value = pa.sturn_time / 0.8f * 100;
                        n_halo = (Behaviour)hit.transform.gameObject.GetComponent("Halo");
                        n_halo.enabled = true;
                        n_reset = true;
                        if (Input.GetKey("q") || isBtnDown)
                        {
                            Debug.DrawRay(gameObject.transform.position + height, gameObject.transform.forward * 1000, Color.blue);
                            pa.sturning = true;
                        }
                    }
                    return;
                }
                else if (hit.collider.tag == "Prop")
                {
                    if (slider.gameObject.activeSelf)
                        slider.gameObject.SetActive(false);
                    if (p_halo != null)
                    {          
                        p_halo.enabled = false;
                        p_reset = false;
                    }
                    if (c_reset)
                    {
                        if(curse != null)
                            curse.cursing = false;
                        c_halo.enabled = false;
                        c_reset = false;
                    }
                    if (n_reset)
                    {
                        n_halo.enabled = false;
                        n_reset = false;
                        if (pa != null)
                            pa.sturning = false;
                    }
                    if (hit.distance <= 3.0f)
                    {
                        Debug.DrawRay(gameObject.transform.position + height, gameObject.transform.forward * 1000, Color.yellow);
                        p_halo = (Behaviour)hit.transform.gameObject.GetComponent("Halo");
                        p_halo.enabled = true;
                        p_reset = true;
                        mesh_name = hit.collider.GetComponent<MeshFilter>().mesh.name;

                        if ((Input.GetKeyDown("q") || isBtnDown) && !prop_cool)
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

                            // Debug.Log("mesh_name : " + mesh_num);
                            ChangeModelAttempt(hit.collider.gameObject);
                            proped = true;
                        }
                    }
                    return;
                }
                else
                {
                    if (slider.gameObject.activeSelf)
                        slider.gameObject.SetActive(false);
                    if (c_reset)
                    {
                        if (curse != null)
                            curse.cursing = false;
                        c_halo.enabled = false;
                        c_reset = false;
                    }
                    if (n_reset)
                    {
                        n_halo.enabled = false;
                        n_reset = false;
                        if (pa != null)
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
                if (slider.gameObject.activeSelf)
                    slider.gameObject.SetActive(false);
                if (curse != null)
                    curse.cursing = false;
                if (pa != null)
                    pa.sturning = false;
            }
        } else
        {
            if (slider.gameObject.activeSelf)
                slider.gameObject.SetActive(false);
            // Debug.Log("prop true");
            if (c_reset)
            {
                if (curse != null)
                    curse.cursing = false;
                c_halo.enabled = false;
                c_reset = false;
            }
            if (n_reset)
            {
                n_halo.enabled = false;
                n_reset = false;
                if (pa != null)
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
                RadialProgress_Mobile.rp.startProgress();
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
        dust_cool = RadialProgress_dust.rp.isProgress();

        if (Input.GetKeyDown("e") && !dust_cool)
        {
            // Debug.Log("dust on");
            mobileClient.cl.setDustStrom(1);
        }
        else if (Input.GetKeyDown("r"))
        {
            // Debug.Log("dust off");
            mobileClient.cl.setDustStrom(0);
        }
    }
}
    