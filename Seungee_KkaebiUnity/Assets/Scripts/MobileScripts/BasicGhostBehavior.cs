using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGhostBehavior : MonoBehaviour
{
    public float timer;
    public float revealTimer;
    public bool beingSeen;
    public bool shouldDie;
    Renderer ghostRenderer;
    public Material ghostMaterialTransparent;
    public Material ghostMaterialRevealed;
    public float yPositionCalibration;
    public GameObject dokkaebiArmature;
    public GameObject dokkaebiAura;
    int prevLife;
    // Start is called before the first frame update
    void Start()
    {

        ghostRenderer = dokkaebiArmature.GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        prevLife = mobile2vr.mobileToVRCl.life;
        if (mobile2vr.mobileToVRCl.GhostBeingSeen())
        {
           
            ghostRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            dokkaebiAura.SetActive(true);
        }
       else
        {
            ghostRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            dokkaebiAura.SetActive(false);
        }
        if(vrClient.cl.getLife()!= prevLife)
        {
            LostLife();
        }
    }
    public void BeingSeen()
    {
        beingSeen = true;
    }
    public void NotSeen()
    {
        beingSeen = false;
    }

    public void HitbyBat()
    {
        ghostRenderer.enabled = false;
        Invoke("ShowGhost", 5.0f);
    }
    public void LostLife()
    {
        ghostRenderer.enabled = false;
        Invoke("ShowGhost", 5.0f);
    }
    void ShowGhost()
    {
        ghostRenderer.enabled = true;
    }
}
