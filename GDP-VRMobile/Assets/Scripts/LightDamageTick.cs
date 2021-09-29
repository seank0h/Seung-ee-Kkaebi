using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDamageTick : MonoBehaviour
{
    public float damage;
    public float delayBeforeDmg;
    public float tickTime;

    public BasicGhostBehavior ghostEntity;
    // Start is called before the first frame update
    void Start()
    {
        damage = 2;
        delayBeforeDmg = 0.25f;
        tickTime = 0.5f;
        ghostEntity = GetComponent<BasicGhostBehavior>();
        StartCoroutine(DPS());
    }

    IEnumerator DPS()
    {
        yield return new WaitForSeconds(delayBeforeDmg);

        while(ghostEntity.beingSeen)
        {
            ghostEntity.TakeDamage(damage);
            yield return new WaitForSeconds(tickTime);
        }
        Destroy(this);
    }
   
    
}
