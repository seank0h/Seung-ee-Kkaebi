using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRDustParticleEffect : MonoBehaviour
{
    public static VRDustParticleEffect VRdpe;
    public ParticleSystem dustEffect;
    public bool effectOn;
    float lowerEmissionRate;
    public float NormalEmissionRate;

    private GameObject Removal, originCol;
    private GameObject removerOrigin;
    private GameObject[] removers;
    private Renderer rendO;
    private Renderer[] rend;
    void Start()
    {
        if(VRdpe && VRdpe != this)
            Destroy(this);
        else
            VRdpe = this;

        effectOn = false;
        NormalEmissionRate = 325;

        removerOrigin = GameObject.Find("RemoverOrigin");
        removers = new GameObject[5];
        removers[0] = GameObject.Find("Remover_1");
        removers[1] = GameObject.Find("Remover_2");
        removers[2] = GameObject.Find("Remover_3");
        removers[3] = GameObject.Find("Remover_4");
        removers[4] = GameObject.Find("RemoverFinal");

        rend = new Renderer[5];
        
        //rendO = Removal.transform.GetChild(0).GetComponent<Renderer>();
        

        Removal = GameObject.Find("DustStormRemoval");
        originCol = GameObject.Find("OriginCol");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
        
            if (effectOn == false)
            {
                Debug.Log("FALSE@@@@@@@@@@@@@@@@");
                var dustEffectEmission = dustEffect.emission;
                dustEffectEmission.rateOverTime = NormalEmissionRate;
                dustEffect.Play();
                effectOn = true;

                //DustStormRemover.dsr.RemoveDustStorm();
                RemoveDustStorm();
                //Invoke("RemoveDustStorm", 0.5f);
            }
        }
        if(Input.GetKeyDown(KeyCode.L) || removers[4].activeInHierarchy == false)
        {
            if (effectOn)
            {
                Debug.Log("In Removing Dust Storm");
                var dustEffectEmission = dustEffect.emission;
                lowerEmissionRate--;
                dustEffectEmission.rateOverTime = lowerEmissionRate;
                effectOn = false;
            }
        }

    }

    public void RemoveDustStorm(){
        Removal.transform.GetChild(0).gameObject.SetActive(true);
        Removal.transform.GetChild(1).gameObject.SetActive(true);
        Removal.transform.GetChild(2).gameObject.SetActive(true);
        Removal.transform.GetChild(3).gameObject.SetActive(true);
        Removal.transform.GetChild(4).gameObject.SetActive(true);
        Removal.transform.GetChild(5).gameObject.SetActive(true);

        StartCoroutine(RemoverIn());
        //StartCoroutine(AlphaIn());


    }
    public IEnumerator RemoverIn(){
        float currentTime = 0;

        rendO = Removal.transform.GetChild(0).GetComponent<Renderer>();
        rend[0] = Removal.transform.GetChild(1).GetComponent<Renderer>();

        while (currentTime < 1){
            rendO.material.color = Color.Lerp(Color.clear, Color.red, currentTime);
            rend[0].material.color = Color.Lerp(Color.clear, Color.red, currentTime);
            yield return null;
            currentTime += Time.deltaTime;
        }
    }
    
    /*
    private IEnumerator AlphaIn(){
        Renderer rendO = Removal.transform.GetChild(0).GetComponent<Renderer>();
        float duration = 1;
        float elapsedTime = 0;
        float startValue = rendO.material.color.a;
        float endValue = 255;
        while(elapsedTime < duration){
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            rendO.material.color = new Color(rendO.material.color.r, rendO.material.color.g, rendO.material.color.b, newAlpha);
            yield return null;
        }
    }
    */
}
