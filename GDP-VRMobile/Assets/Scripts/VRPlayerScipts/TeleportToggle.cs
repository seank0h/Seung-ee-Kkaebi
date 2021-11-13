using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportToggle : MonoBehaviour
{    
    
    [SerializeField]
    private Material activeMat;
    [SerializeField]
    private Material holdMat;
    [SerializeField]
    private Material inactiveMat;

    [Header("Fade Screen")]
    public Image blackScreen;

    public bool teleportLock;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BoneTriggerLogic>() != null)
        {
            GetComponent<MeshRenderer>().material = holdMat;
            StartCoroutine(FadeTeleport());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<BoneTriggerLogic>() != null)
        {
            GetComponent<MeshRenderer>().material = inactiveMat;
        }
    }

    private IEnumerator FadeTeleport()
    {
        // Make sure teleport can't be called again
        teleportLock = true;
            
        // Reset Time counter variable
        float currentTime = 0;
        // Loop until counter is done
        while (currentTime < 1)
        {
            // Fade out screen
            blackScreen.color = Color.Lerp(Color.clear, Color.black, currentTime);
            // Wait one frame
            yield return null;
            // Increment Timer
            currentTime += Time.deltaTime;
        }
        // Set full black screen
        blackScreen.color = Color.black;
            
        // Wait one second
        yield return new WaitForSeconds(0.1f);
        // Reset timer again
        currentTime = 0;
        // Loop until timer is done again
        while (currentTime < 1)
        {
            // Fade in screen
            blackScreen.color = Color.Lerp(Color.black, Color.clear, currentTime);
            // Wait one frame
            yield return null;
            // Increment Timer
            currentTime += Time.deltaTime;
        }
        // Allow teleporting again
        teleportLock = false;
    }
}
