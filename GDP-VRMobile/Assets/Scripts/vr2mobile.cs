using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class vr2mobile : MonoBehaviour
{
    public static vr2mobile vm;
    // 0 번째 원소는 현재 상태, 1번째 원소는 이전 상태를 말함
    int[] bulletCol = new int[2];
    int[] catchMobile = new int[2];
    int[] dustClean = new int[2];
    int[] isFlare = new int[2];
    int[] vrPos = new int[2]; // 0~3
    int startNPC;
    Vector3 lHand, rHand, flarePos;
    public GameObject flare;
    public GameObject bullet;
    public GameObject player;
    
    public ParticleSystem dustEffect;
    bool effectOn;
    public float NormalEmissionRate;
    float lowerEmissionRate;

    char[] c_detail = new char[4];
    char[] n_detail = new char[5];
    ThirdPersonController playecon;


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
        startNPC = mobileClient.cl.getstartNPCMove();

        effectOn = false;
        NormalEmissionRate = 50;

        mobileClient.cl.setstartNPCMove(1);
        c_detail = mobileClient.cl.getCurse().ToCharArray();
        n_detail = mobileClient.cl.getNPCMat().ToCharArray();
        playecon = player.GetComponent<ThirdPersonController>();

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

        mobileClient.cl.setstartNPCMove(1);
        //Debug.Log(mobileClient.cl.getstartNPCMove());

        
        if (vrPos[0] == 0)
        {
            mobileClient.cl.setstartNPCMove(3);
            //Debug.Log("스타트가 3인가? : " + mobileClient.cl.getstartNPCMove());
        }

        //Debug.Log(mobileClient.cl.getVRPos());

        Debug.Log("dust storm : " + mobileClient.cl.getDustStrom());

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
        if (mobileClient.cl.getDustStrom() == 0)
        {
            if (effectOn)
            {
                var dustEffectEmission = dustEffect.emission;
                lowerEmissionRate--;
                dustEffectEmission.rateOverTime = lowerEmissionRate;
                effectOn = false;
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
        

        if (catchMobile[0] != catchMobile[1])
        {
            int life = mobileClient.cl.getLife();
            mobileClient.cl.setLife(life - 1);
            Debug.Log(mobileClient.cl.getLife());
            Debug.Log("first : " + playecon.MoveSpeed);
            playecon.MoveSpeed = 10;
            Invoke("speed_return", 5f);
        }
        
        if (vrPos[0] != vrPos[1])
        {
            // vr캐릭터 보이는 위치를 이동해야겠지
        }
    }

    public bool go()
    {
        return mobileClient.cl.getstartNPCMove() == 3;
    }

    public void curse_send(int index)
    {
        c_detail[index] = '1';
        string result = new string(c_detail);
        Debug.Log(result);
        mobileClient.cl.setCurse(result);
    }

    public void strun_send(int index)
    {
        // Debug.Log("index : " + index);
        n_detail[index] = '1';
        string result = new string(n_detail);
        Debug.Log(result);
        mobileClient.cl.setNPCMat(result);
    }

    public void alert_send(int index)
    {
        // Debug.Log("index : " + index);
        n_detail[index] = '2';
        string result = new string(n_detail);
        Debug.Log(result);
        mobileClient.cl.setNPCMat(result);
    }

    public void alert_end(int index)
    {
        // Debug.Log("index : " + index);
        n_detail[index] = '0';
        string result = new string(n_detail);
        Debug.Log(result);
        mobileClient.cl.setNPCMat(result);
    }

    void speed_return()
    {
        playecon.MoveSpeed = 2;
    }
}
