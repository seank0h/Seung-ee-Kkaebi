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

    // Start is called before the first frame update
    void Start()
    {

        ghostRenderer = dokkaebiArmature.GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {

        if (beingSeen)
        {
            revealTimer -= Time.deltaTime;
            ghostRenderer.material = ghostMaterialRevealed;
        }
        if (revealTimer <= 0)
        {
            ghostRenderer.material = ghostMaterialTransparent;
            revealTimer = 5.0f;
            beingSeen = false;
        }

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
    public void HitByBullet()
    {
        ghostRenderer.enabled = false;
        Invoke("ShowGhost", 5.0f);
    }
    void ShowGhost()
    {
        ghostRenderer.enabled = true;
    }
}
