using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAlart : MonoBehaviour
{
    GameObject player;
    float stay = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerArmature");
        this.gameObject.GetComponent<Renderer>().material.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= 5)
        {
            stay += Time.deltaTime;
            if (stay >= 2f)
            {
                this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
            }
        }
        else
        {
            stay = 0;
            this.gameObject.GetComponent<Renderer>().material.color = Color.black;
        }
    }
}