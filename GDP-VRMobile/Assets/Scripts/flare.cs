using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flare : MonoBehaviour
{
    float timer = 10.0f;
    private AudioSource flareAudio;
 
    // Start is called before the first frame update
    void Start()
    {
        flareAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.gameObject.tag == "Dokkaebi")
        {
            Debug.Log("come in");
            // RayCast_cam.rc.change_blue();
            mobileClient.cl.setPlayerMat(1);
            flareAudio.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Dokkaebi")
        {
            Debug.Log("come out");
            Invoke("color_back", 5f);
        }
    }

    private void color_back()
    {
        // RayCast_cam.rc.change_trans();
        mobileClient.cl.setPlayerMat(0);
    }
}
