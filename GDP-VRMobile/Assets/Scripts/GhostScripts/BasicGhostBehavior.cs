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
        yPositionCalibration = 1.0f;
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
    public void TakeDamage(float dmg)
    {

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

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name=="OVRHandPrefab_L" || other.gameObject.name=="OVRHandPrefab_R")
        {
            Debug.Log("I got Hit by hands");
        }
    }
}
