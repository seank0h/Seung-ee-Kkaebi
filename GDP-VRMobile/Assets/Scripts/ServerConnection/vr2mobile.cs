using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.UI;

public class vr2mobile : MonoBehaviour
{
    public static vr2mobile vm;
    // 0 번째 원소는 현재 상태, 1번째 원소는 이전 상태를 말함
    int[] bulletCol = new int[2];
    int[] catchMobile = new int[2];
    int[] dustClean = new int[2];
    int[] isFlare = new int[2];
    int[] vrPos = new int[2]; // 0~3
    int[] playermat = new int[2];
    int batEnable, min, sec;
    int bullet_damage = 10, bat_damage = 25;
    float time;

    Vector3 lHand, rHand, flarePos;
    public GameObject flare;
    public GameObject bullet;
    public GameObject player;
    public GameObject hitEffect;
    public GameObject bulletEffect;
    public GameObject bat;
    public GameObject[] Jangseung = new GameObject[4];
    public GameObject healthbar;

    public SkinnedMeshRenderer Drenderer;
    public Material ghostMaterialTransparent;
    public Material ghostMaterialRevealed;

    int bulletCnt = 0;
    
    public ParticleSystem dustEffect;
    bool effectOn;
    public float NormalEmissionRate;
    float lowerEmissionRate;

    char[] c_detail = new char[4];
    char[] n_detail = new char[5];
    ThirdPersonController playecon;


    private AudioSource slowAudio;

    // Start is called before the first frame update
    void Start()
    {
        bulletCol[0] = mobileClient.cl.getBulletCollision();
        bulletCol[1] = mobileClient.cl.getBulletCollision();
        catchMobile[0] = mobileClient.cl.getCatchEvent();
        catchMobile[1] = mobileClient.cl.getCatchEvent();
        dustClean[0] = mobileClient.cl.getDustClean();
        dustClean[1] = mobileClient.cl.getDustClean();
        isFlare[0] = mobileClient.cl.getIsFlare();
        isFlare[1] = mobileClient.cl.getIsFlare();
        vrPos[0] = mobileClient.cl.getVRPos();
        vrPos[1] = mobileClient.cl.getVRPos();
        playermat[0] = mobileClient.cl.getPlayerMat();
        playermat[1] = mobileClient.cl.getPlayerMat();
        mobileClient.cl.setstartNPCMove(1);

        effectOn = false;
        NormalEmissionRate = 50;

        mobileClient.cl.setstartNPCMove(1);
        c_detail = mobileClient.cl.getCurse().ToCharArray();
        n_detail = mobileClient.cl.getNPCMat().ToCharArray();
        playecon = player.GetComponent<ThirdPersonController>();

        batEnable = mobileClient.cl.getBatEnabled();
        Jangseung[vrPos[0]].SetActive(true);

        slowAudio = GetComponent<AudioSource>();

        if (vm && vm != this)
            Destroy(this);
        else
            vm = this;
    }

    // Update is called once per frame
    void Update()
    {
        dustClean[1] = dustClean[0];
        dustClean[0] = mobileClient.cl.getDustClean();
        bulletCol[1] = bulletCol[0];
        bulletCol[0] = mobileClient.cl.getBulletCollision();
        catchMobile[1] = catchMobile[0];
        catchMobile[0] = mobileClient.cl.getCatchEvent();
        isFlare[1] = isFlare[0];
        isFlare[0] = mobileClient.cl.getIsFlare();
        vrPos[1] = vrPos[0];
        vrPos[0] = mobileClient.cl.getVRPos();
        lHand = mobileClient.cl.getLHand();
        rHand = mobileClient.cl.getRHand();
        flarePos = mobileClient.cl.getFlare();
        c_detail = mobileClient.cl.getCurse().ToCharArray();
        n_detail = mobileClient.cl.getNPCMat().ToCharArray();
        batEnable = mobileClient.cl.getBatEnabled();
        playermat[1] = playermat[0];
        playermat[0] = mobileClient.cl.getPlayerMat();

        // Debug.Log("flarepos : " + flarePos);

        if (playermat[1] != playermat[0])
        {
            if (playermat[0] == 0)
            {
                Drenderer.material = ghostMaterialTransparent;
            }
            else
            {
                Drenderer.material = ghostMaterialRevealed;
            }
        }

        if (batEnable == 0)
        {
            bat.SetActive(false);
        } else
        {
            bat.SetActive(true);
        }

        if (mobileClient.cl.getDustStrom() == 1)
        {

            if (effectOn == false)
            {
                var dustEffectEmission = dustEffect.emission;
                dustEffectEmission.rateOverTime = NormalEmissionRate;
                dustEffect.Play();
                effectOn = true;
            }
        }

        if (dustClean[0] == 1)
        {
            mobileClient.cl.setDustStrom(0);
        }
        // Debug.Log("duststorm : " + mobileClient.cl.getDustStrom());
        // Debug.Log("dustclean : " + dustClean[0]);

        if (mobileClient.cl.getDustStrom() == 0)
        {
            if (effectOn)
            {
                var dustEffectEmission = dustEffect.emission;
                lowerEmissionRate--;
                dustEffectEmission.rateOverTime = lowerEmissionRate;
                effectOn = false;
                RadialProgress_dust.rp.startProgress();
            }
        }


        if (isFlare[0] != isFlare[1])
        {
            if (isFlare[0] == 1)
            {
                Debug.Log("flare");
                Instantiate(flare, flarePos, Quaternion.identity);
            }
            else if (isFlare[0] == 2)
            {
                Debug.Log("bullet");
                Instantiate(bullet, lHand, Quaternion.Euler(flarePos));
            }
        }

        // Debug.Log("camo : " + catchMobile[0]);
        if (catchMobile[0] != catchMobile[1])
        {
            if (catchMobile[0] == 1)
            {
                Vibration.Vibrate(1000);
                Instantiate(hitEffect, player.transform.position, Quaternion.identity);
                int life = mobileClient.cl.getLife();
                healthbar.GetComponent<progressLiquid>().decreaseLevel(bat_damage);
                Raycast.rc.prop();
                playecon.MoveSpeed = 10;
                Invoke("speed_return", 5f);
            }
        }

        //Debug.Log(bulletCol[0]);
        if(bulletCol[0] != bulletCol[1] && bulletCol[0] == 1)
        {
            healthbar.GetComponent<progressLiquid>().decreaseLevel(bullet_damage);
            Vibration.Vibrate(300);
            playecon.MoveSpeed -= 0.4f;
            Instantiate(bulletEffect, player.transform.position, Quaternion.identity);
            if (playecon.MoveSpeed < 3.1f)
            {
                playecon.MoveSpeed = 3.1f;
            }
            slowAudio.Play();
        }

        if (vrPos[0] != vrPos[1])
        {
            Jangseung[vrPos[1]].SetActive(false);
            Jangseung[vrPos[0]].SetActive(true);
        }
        // Debug.Log("life : " + mobileClient.cl.getLife());
        // Debug.Log("playermat : " + mobileClient.cl.getPlayerMat());
    }

    public void curse_send(int index)
    {
        c_detail[index] = '1';
        string result = new string(c_detail);
        // Debug.Log("c_detail : " + result);
        mobileClient.cl.setCurse(result);
    }

    public void strun_send(int index)
    {
       
        // Debug.Log("index : " + index);
        n_detail[index] = '1';
        string result = new string(n_detail);
        // Debug.Log(result);
        mobileClient.cl.setNPCMat(result);
    }

    public void alert_send(int index)
    {
        
        //Debug.Log("alart sound");
        n_detail[index] = '2';
        string result = new string(n_detail);
        // Debug.Log(result);
        mobileClient.cl.setNPCMat(result);
    }

    public void alert_end(int index)
    {
        // Debug.Log("index : " + index);
        n_detail[index] = '0';
        string result = new string(n_detail);
        // Debug.Log(result);
        mobileClient.cl.setNPCMat(result);
    }

    void speed_return()
    {
        Raycast.rc.not_prop();
        playecon.MoveSpeed = 5;
    }
}
