using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGhostBehavior : MonoBehaviour
{
    public float timer;
    public float timeToKill;
    public float healthPoints;
    public bool beingSeen;
    public bool dmgTickCalled;
    public bool shouldDie;
    // Start is called before the first frame update
    void Start()
    {
        timer = timeToKill;
        healthPoints = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(beingSeen & dmgTickCalled==false)
        {
            BeingDamaged();
            dmgTickCalled = true;
        }
        if(!beingSeen)
        {
            dmgTickCalled = false;
        }
        if (shouldDie)
            Death();
    }
    public void BeingDamaged()
    {
        gameObject.AddComponent<LightDamageTick>();
    }
    public void TakeDamage(float dmg)
    {
        Debug.Log("Taking Damage");
        healthPoints -= dmg;
    }
    public void Death()
    {
        Debug.Log("Ghost Die");
        Destroy(gameObject);
    }
}
