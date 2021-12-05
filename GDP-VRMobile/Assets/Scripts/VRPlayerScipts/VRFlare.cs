using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRFlare : MonoBehaviour
{
    public GameObject vrFlare;
    public GameObject positionPlaceHolder;
    void Start()
    {
        var physicsMotion = GetComponentInChildren<RFX4_PhysicsMotion>(true);
        if (physicsMotion != null) physicsMotion.CollisionEnter += CollisionEnter;

        var raycastCollision = GetComponentInChildren<RFX4_RaycastCollision>(true);
        if (raycastCollision != null) raycastCollision.CollisionEnter += CollisionEnter;
    }

    private void CollisionEnter(object sender, RFX4_PhysicsMotion.RFX4_CollisionInfo e)
    {
        
        positionPlaceHolder.transform.position = e.HitPoint;
        Instantiate(vrFlare, positionPlaceHolder.transform.position, Quaternion.identity);

    }

}
