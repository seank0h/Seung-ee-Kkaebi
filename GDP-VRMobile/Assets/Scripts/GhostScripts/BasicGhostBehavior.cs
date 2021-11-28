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


    // Start is called before the first frame update
    void Start()
    {
        
        ghostRenderer = this.GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
       
        if(beingSeen)
        {
            revealTimer -= Time.deltaTime;
            ghostRenderer.material = ghostMaterialRevealed;
        }
        if(beingSeen==false)
        {
            revealTimer -= Time.deltaTime;
            if(revealTimer<=0)
            {
                ghostRenderer.material = ghostMaterialTransparent;
                revealTimer = 5.0f;
            }
        }
        
        if (shouldDie)
            Death();
    }
    public void Death()
    {
        Debug.Log("Ghost Die");
        Destroy(gameObject);
    }
    public void BeingSeen()
    {
        Debug.Log("Being Seen Called");
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
    void ShowGhost()
    {
        ghostRenderer.enabled = true;
    }
}
