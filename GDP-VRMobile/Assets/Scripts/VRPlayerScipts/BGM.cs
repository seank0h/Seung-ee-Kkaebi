using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioClip idle, danger, emergency;
    private AudioSource bgm;
    private float startVolume;
    
    void Start()
    {
        //bgm.clip = idle;
        bgm = GetComponent<AudioSource>();
        startVolume = bgm.volume;
        Debug.Log("Start Volume : " + startVolume);
        //bgm.Play();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J)){
            StartCoroutine(AudioFadeOutInIdle());
        }
        if(Input.GetKeyDown(KeyCode.H)){
            StartCoroutine(AudioFadeOutInDanger());
        }
        if(Input.GetKeyDown(KeyCode.G)){
            StartCoroutine(AudioFadeOutInEmergency());
        }
    }

    public IEnumerator AudioFadeOutInIdle(){
        startVolume = bgm.volume;
        Debug.Log("Start Volume : " + startVolume);
        while(bgm.volume > 0){
            bgm.volume -= startVolume * Time.deltaTime / 2;
            yield return null;
        }
        bgm.Stop();

        yield return new WaitForSeconds(0.1f);
        startVolume = bgm.volume;
        Debug.Log("Start Volume@@ : " + startVolume);

        bgm.clip = idle;
        bgm.Play();

        while(bgm.volume < 1){
            bgm.volume += startVolume + Time.deltaTime / 2;
            yield return null;
        }
        startVolume = bgm.volume;
        Debug.Log("Start Volume## : " + startVolume);      
    }

    public IEnumerator AudioFadeOutInDanger(){
        startVolume = bgm.volume;
        Debug.Log("Start Volume : " + startVolume);
        while(bgm.volume > 0){
            bgm.volume -= startVolume * Time.deltaTime / 2;
            yield return null;
        }
        bgm.Stop();

        yield return new WaitForSeconds(0.1f);
        startVolume = bgm.volume;
        Debug.Log("Start Volume@@ : " + startVolume);

        bgm.clip = danger;
        bgm.Play();

        while(bgm.volume < 1){
            bgm.volume += startVolume + Time.deltaTime / 2;
            yield return null;
        }
        startVolume = bgm.volume;
        Debug.Log("Start Volume## : " + startVolume);      
    }

    public IEnumerator AudioFadeOutInEmergency(){
        startVolume = bgm.volume;
        Debug.Log("Start Volume : " + startVolume);
        while(bgm.volume > 0){
            bgm.volume -= startVolume * Time.deltaTime / 2;
            yield return null;
        }
        bgm.Stop();

        yield return new WaitForSeconds(0.1f);
        startVolume = bgm.volume;
        Debug.Log("Start Volume@@ : " + startVolume);

        bgm.clip = emergency;
        bgm.Play();

        while(bgm.volume < 1){
            bgm.volume += startVolume + Time.deltaTime / 2;
            yield return null;
        }
        startVolume = bgm.volume;
        Debug.Log("Start Volume## : " + startVolume);
    }

    /*
    public IEnumerator AudioFadeInDanger(){
        Debug.Log("Audio Fade In DANGER@@@@@@");
        startVolume = bgm.volume;
        bgm.clip = danger;
        bgm.Play();
        Debug.Log("Start Volume : " + startVolume);

        while(bgm.volume < 1){
            bgm.volume += startVolume + Time.deltaTime / 2;
            yield return null;
        }
        startVolume = bgm.volume;       
    }
    */
    /*
    public IEnumerator AudioFadeInEmergency(){
        Debug.Log("Audio Fade In Emergency#######");
        startVolume = bgm.volume;
        bgm.clip = emergency;
        bgm.Play();
        Debug.Log("Start Volume : " + startVolume);

        while(bgm.volume < 1){
            bgm.volume += startVolume + Time.deltaTime / 2;
            yield return null;
        }
        startVolume = bgm.volume;
    }
    */
}
