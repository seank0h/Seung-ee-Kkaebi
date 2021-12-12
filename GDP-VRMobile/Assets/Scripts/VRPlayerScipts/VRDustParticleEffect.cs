using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRDustParticleEffect : MonoBehaviour
{
    public static VRDustParticleEffect VRdpe;
    public ParticleSystem dustEffect;
    public bool effectOn;
    bool emissionLowered;
    float lowerEmissionRate;
    public float NormalEmissionRate;

    private GameObject Removal, originCol;
    private GameObject removerOrigin;
    private GameObject[] removers;
    public Vector3[] pos;
    public Vector3 originalPos;
    private Renderer[] rend;
    private AudioSource stormAudio;
    private float startVolume;

    void Start()
    {
        if(VRdpe && VRdpe != this)
            Destroy(this);
        else
            VRdpe = this;

        effectOn = false;
        NormalEmissionRate = 250;

        removerOrigin = GameObject.Find("RemoverOrigin");
        removers = new GameObject[5];
        removers[0] = GameObject.Find("Remover_1");
        removers[1] = GameObject.Find("Remover_2");
        removers[2] = GameObject.Find("RemoverFinal");

        rend = new Renderer[3];
        pos = new Vector3[4];
        for(int i = 0; i < pos.Length; i++){
            pos[i] = Vector3.zero;
        }
        originalPos = Vector3.zero;
      
        Removal = GameObject.Find("DustStormRemoval");
        originCol = GameObject.Find("OriginCol");

        stormAudio = GameObject.Find("Manager").GetComponent<AudioSource>();
        startVolume = stormAudio.volume;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        //if(mobile2vr.mobileToVRCl.DustStormInteraction() && mobile2vr.mobileToVRCl.dustStormState == true)
        {
            Debug.Log("Is this being called");
            if (effectOn == false)
            {
                Debug.Log("Starting Dust Storm");
                var dustEffectEmission = dustEffect.emission;
                dustEffectEmission.rateOverTime = NormalEmissionRate;
                dustEffect.Play();
                effectOn = true;
                stormAudio.volume = 1f;
                stormAudio.Play();
                RemoveDustStorm();
            }
        }
    }

    public void EndDustStorm(){
        mobile2vr.mobileToVRCl.dustStormState = false;
        StartCoroutine(AudioFadeOut());
        vrClient.cl.setDustClean(1);
        effectOn = false;
    }

    private void initObj(){
        removers = new GameObject[5];
        removers[0] = GameObject.Find("Remover_1");
        removers[1] = GameObject.Find("Remover_2");
        removers[2] = GameObject.Find("RemoverFinal");
        removerOrigin = GameObject.Find("RemoverOrigin");
    }

    public void RemoveDustStorm(){
        for(int i = 0; i < 4; i++){
            if(i == 0){
                Removal.transform.GetChild(i).gameObject.SetActive(true);
            }else{
                Removal.transform.GetChild(i).gameObject.SetActive(true);
                Removal.transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
                Removal.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
            }
            initObj();
            if(i == 0){              
                pos[i] = removerOrigin.transform.position;
                originalPos = pos[i];
            }else{
                pos[i] = removers[i-1].transform.position;
            }
        }
        //StartCoroutine(RemoverIn());
    }

    public IEnumerator AudioFadeOut(){
        startVolume = stormAudio.volume;

        while(stormAudio.volume > 0){
            stormAudio.volume -= startVolume * Time.deltaTime / 2;
            yield return null;
        }
        stormAudio.Stop();
        stormAudio.volume = startVolume;
    }
}
