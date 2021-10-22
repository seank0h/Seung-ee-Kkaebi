using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float fireRate = 1f;
    public float timeBeforeDestroyed = 5f;
    private bool collided = false;
    private Rigidbody rb = null;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, timeBeforeDestroyed);
    }

    void FixedUpdate()
    {
        // Move the RB of the bullet forward in base at its speed
        if (speed != 0 && rb != null){
            rb.position += (transform.forward) * (speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision co){
        if (co.gameObject.tag != "Bullet" && !collided){
            collided = true;
            speed = 0f;
            Destroy(gameObject);
        }
    }
}