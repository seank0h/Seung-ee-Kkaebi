using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwap : MonoBehaviour
{
    public Transform currLocation;
    public List<Transform> teleportationLocations;
    public int whichLocation;

  
    void Start()
    {
        currLocation = gameObject.transform;
    }
    void CardinalDirectionSelection()
    {
        if (OVRInput.Get(OVRInput.RawButton.A) || OVRInput.Get(OVRInput.RawButton.B))
        {
            if (whichLocation == 0)
            {
                whichLocation = teleportationLocations.Count - 1;
            }
            else
            {
                whichLocation -= 1;
            }
            Swap();
        }
        if (OVRInput.Get(OVRInput.RawButton.X) || OVRInput.Get(OVRInput.RawButton.Y))
        {
            if (whichLocation == teleportationLocations.Count - 1)
            {
                whichLocation = 0;
            }
            else
            {
                whichLocation += 1;
            }
            Swap();
        }
    }
    void CardinalDirectionTeleportation()
    {
        currLocation = teleportationLocations[whichLocation];
    }
    void Swap()
    {
       
        
      
        //cam.LookAt = currCharacter.Find("PlayerCameraRoot");
    }
   
}
