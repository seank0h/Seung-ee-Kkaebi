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
                    timeToFire = Time.time + 1.0f / projectilePrefab.GetComponent<Bullet>().fireRate;
                    Shoot();
                }
                break;

            case ShootMode.Single:
                if (!hasShoot){
                    hasShoot = true;
                    Debug.Log("Shooting in Single");
                    timeToFire = Time.time + 1.0f / projectilePrefab.GetComponent<Bullet>().fireRate;
                    Shoot();
                }
                break;
        }
    }

    private void Shoot(){
        // In the End we will going to shoot a bullet
        vrClient.cl.setIsFlare(2);
        GameObject bullet = Instantiate(projectilePrefab, hand.position, Quaternion.identity);
        bullet.transform.localRotation = hand.rotation;
    }

    // Method to put in the Event when the gesture are not recognized
    public void StopShoot(){
        hasShoot = false;
        Debug.Log("Stop Shooting");
    }
}
