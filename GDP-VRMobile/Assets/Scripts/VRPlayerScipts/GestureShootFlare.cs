using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureShootFlare : MonoBehaviour
{
    [Header("SpawnTransform")]
    // Transform where the bullet have to be Instantiated
    public Transform hand;

    [Header("FlarePrefab")]
    // GameObject used as Bullet to Instantiate
    public GameObject projectilePrefab;
    public GameObject positionPlaceHolder;

    // Enum where we set the mode of shooting the bullet
    public enum ShootMode{
        Auto,
        Single
    }

    [Header("ShootMethod")]
    // Choose the method of firing the bullets from Inspector
    public ShootMode  shootMode;

    // Boolean to use in single ShootMode
    private bool hasShoot = false;

    // Float used to calculate the time need to fire the bullet, related to teh bullet fireRate
    private float timeToFire = 0.0f;

    // Method to add in the Event of the gesture you want to make shoot
    public void OnShoot(){
        // Switch between the two modes
        switch (shootMode)
        {
            case ShootMode.Auto:
                Debug.Log("Shooting in Auto");
                if (Time.time >= timeToFire){
                    
                    Shoot();
                }
                break;

            case ShootMode.Single:
                if (!hasShoot){
                    hasShoot = true;
                    Debug.Log("Shooting in Single");
                    
                    Shoot();
                }
                break;
        }
    }

    private void Shoot(){
        RaycastHit hit;
        if(Physics.Raycast(hand.transform.position, hand.transform.forward,out hit))
        {
            vrClient.cl.setIsFlare(1);
            Debug.Log("Shootflare");
            Debug.DrawRay(hand.transform.position, hand.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow); 
            Vector3 hitPosition = hit.point;
            positionPlaceHolder.transform.position = hitPosition;
            Instantiate(projectilePrefab, positionPlaceHolder.transform.position, transform.rotation);
            Invoke("DelayMessage", 0.5f);
            Invoke("CooldownForFlare", 30.0f);
        }

        // In the End we will going to shoot a bullet
        //GameObject flare = Instantiate(projectilePrefab, hand.position, Quaternion.identity);
        //flare.transform.localRotation = hand.rotation;
    }

    // Method to put in the Event when the gesture are not recognized
    public void StopShoot(){
        
        Debug.Log("Stop Shooting");
    }
    private void DelayMessage()
    {
        vrClient.cl.setIsFlare(0);
    }
    public void CooldownForFlare()
    {
        hasShoot = false;
    }
}
