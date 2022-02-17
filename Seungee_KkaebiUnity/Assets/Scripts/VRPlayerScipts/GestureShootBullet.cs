using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureShootBullet : MonoBehaviour
{
    [Header("SpawnTransform")]
    // Transform where the bullet have to be Instantiated
    public Transform hand;

    [Header("BulletPrefab")]
    // GameObject used as Bullet to Instantiate
    public GameObject projectilePrefab;
    public GameObject visualEffectToSpawn;

    public GameObject flare_pos;

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

                if (Time.time >= timeToFire && VRDustParticleEffect.VRdpe.effectOn==false){
                    timeToFire = Time.time + 1.0f / 1.0f;
                    Shoot();
                }
                break;

            case ShootMode.Single:
                if (!hasShoot){
                    hasShoot = true;
 
                    timeToFire = Time.time + 1.0f / projectilePrefab.GetComponent<Bullet>().fireRate;
                    Shoot();
                }
                break;
        }
    }

    private void Shoot(){
        BulletRadialProgress.rp.start = true;
        // In the End we will going to shoot a bullet
        vrClient.cl.setIsFlare(2);
        Vector3 handRotation;
        handRotation = hand.rotation.eulerAngles;
        flare_pos.transform.position = handRotation;
        GameObject bullet = Instantiate(projectilePrefab, hand.position, Quaternion.identity);
        Invoke("DelayMessage", 0.25f);
        bullet.transform.localRotation = hand.rotation;
    }

    // Method to put in the Event when the gesture are not recognized
    public void StopShoot(){
        hasShoot = false;

    }
    private void DelayMessage()
    {
        vrClient.cl.setIsFlare(0);
    }

}
