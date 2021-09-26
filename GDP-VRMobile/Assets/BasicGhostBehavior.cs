using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGhostBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Death()
    {
        Debug.Log("Ghost Die");
        Destroy(gameObject);
    }
}
