using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFlareTest : MonoBehaviour
{
    public GameObject flareObject;
    public float flareCoolDown;
    public bool canShoot;
    void Start()
    {
        canShoot = true;
        flareCoolDown = 25.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)&&canShoot)
        {
            RaycastHit hit;
            if(Physics.Raycast(gameObject.transform.position,gameObject.transform.forward,out hit))
            {
                Debug.Log("Shootflare");
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Vector3 hitPosition = hit.point;
                Instantiate(flareObject, hitPosition,transform.rotation);
            }
            canShoot = false;
        }
        FlareCooldown();
    }
    void FlareCooldown()
    {
        if(canShoot==false)
        {
            flareCoolDown -= Time.deltaTime;
        }
        if(flareCoolDown<=0)
        {
            canShoot = true;
        }
    }
}
