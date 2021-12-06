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

    LineRenderer aimLine;
    // Enum where we set the mode of shooting the bullet
    public enum ShootMode
    {
        Auto,
        Single
    }

    [Header("ShootMethod")]
    // Choose the method of firing the bullets from Inspector
    public ShootMode shootMode;

    // Boolean to use in single ShootMode
    private bool hasShoot = false;

    // Float used to calculate the time need to fire the bullet, related to teh bullet fireRate
    private float timeToFire = 0.0f;

    // Method to add in the Event of the gesture you want to make shoot
    public void OnShoot()
    {
        // Switch between the two modes
        switch (shootMode)
        {
            case ShootMode.Auto:
                Debug.Log("Shooting in Auto");
                if (Time.time >= timeToFire)
                {

                    Shoot();
                }
                break;

            case ShootMode.Single:
                if (!hasShoot && VRDustParticleEffect.VRdpe.effectOn == false)
                {
                    hasShoot = true;

                    Shoot();
                }
                break;
        }
    }

    private void Shoot()
    {
        //VRFlareCooldownUI.rp.start = true;
        Vector3 handRotation;
        handRotation = hand.rotation.eulerAngles;
        GameObject flare = Instantiate(projectilePrefab, hand.position, Quaternion.identity);
        flare.GetComponent<VRFlare>().positionPlaceHolder = positionPlaceHolder;
        flare.transform.localRotation = hand.rotation;
        Debug.Log("Shootflare");
        vrClient.cl.setIsFlare(1);
        Invoke("DelayMessage", 0.5f);
        RadialProgress.rp.start = true;
        Invoke("CooldownForFlare", 15.0f);
    }
    // Method to put in the Event when the gesture are not recognized
    private void DelayMessage()
    {
        vrClient.cl.setIsFlare(0);
    }
    public void CooldownForFlare()
    {
        hasShoot = false;
    }
}
