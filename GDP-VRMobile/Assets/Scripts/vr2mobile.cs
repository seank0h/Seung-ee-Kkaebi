using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vr2mobile : MonoBehaviour
{
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
    public ParticleSystem dustEffect;
    bool effectOn;
    float lowerEmissionRate;
    public float NormalEmissionRate;

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
        NormalEmissionRate = 300;
        mobileClient.cl.setstartNPCMove(1);
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

        if (startNPC == 2)
        {
            // NPC 움직임
            mobileClient.cl.setstartNPCMove(3);
        }

        if (dustClean[0] != dustClean[1])
        {
            if (dustClean[0] == 1)
            {
                mobileClient.cl.setDustStrom(0);
                if (effectOn == false)
                {
                    var dustEffectEmission = dustEffect.emission;
                    dustEffectEmission.rateOverTime = NormalEmissionRate;
                    dustEffect.Play();
                    effectOn = true;
                }
            }
            else
            {
                if (effectOn)
                {
                    var dustEffectEmission = dustEffect.emission;
                    lowerEmissionRate--;
                    dustEffectEmission.rateOverTime = lowerEmissionRate;
                    effectOn = false;
                }
            }
        }

        if (isFlare[0] != isFlare[1])
        {
            if (isFlare[0] == 1)
            {
                Instantiate(flare, flarePos, Quaternion.identity);
            }
            else if (isFlare[0] == 0)
            {
                Instantiate(bullet, lHand, Quaternion.identity);
            }
        }
        
        if (catchMobile[0] != catchMobile[1])
        {
            if (catchMobile[0] == 1)
            {
                Debug.Log("Jot");
                int life = mobileClient.cl.getLife();
                mobileClient.cl.setLife(life - 1);
            }
        }
        
        if (vrPos[0] != vrPos[1])
        {
            // vr캐릭터 보이는 위치를 이동해야겠지
        }
    }
}
