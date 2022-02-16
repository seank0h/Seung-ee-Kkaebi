using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource hitAudio;
    // Start is called before the first frame update
    void Start()
    {
        hitAudio = GetComponent<AudioSource>();
    }

    public void PlayHitAudio()
    {
        hitAudio.Play();
    }
}
