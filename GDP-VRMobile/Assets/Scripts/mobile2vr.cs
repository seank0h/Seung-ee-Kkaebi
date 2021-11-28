using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobile2vr : MonoBehaviour
{
    public static mobile2vr mobileToVRCl;
    int life, startNPC, playermat, prop, duststorm;
    string[] curse = new string[2];
    string[] npcmat = new string[2];
    char[] c_detail = new char[4];
    char[] n_detail = new char[5];
    public int npcStunState=-1;
    public bool firstStart = false;

    // Start is called before the first frame update
    private void Awake()
    {
        if (mobileToVRCl && mobileToVRCl != this)
            Destroy(this);
        else
            mobileToVRCl = this;
    }
    void Start()
    {
        life = vrClient.cl.getLife();
        startNPC = vrClient.cl.getstartNPCMove();
        playermat = vrClient.cl.getPlayerMat();
        prop = vrClient.cl.getProp();
        duststorm = vrClient.cl.getDustStrom();
        curse[0] = vrClient.cl.getCurse();
        curse[1] = vrClient.cl.getCurse();
        npcmat[0] = vrClient.cl.getNPCMat();
        npcmat[1] = vrClient.cl.getNPCMat();
        c_detail = curse[0].ToCharArray();
        n_detail = npcmat[0].ToCharArray();
    }

    // Update is called once per frame
    void Update()
    {
        life = vrClient.cl.getLife();
        startNPC = vrClient.cl.getstartNPCMove();
        playermat = vrClient.cl.getPlayerMat();
        prop = vrClient.cl.getProp();
        duststorm = vrClient.cl.getDustStrom();
        curse[1] = curse[0];
        curse[0] = vrClient.cl.getCurse();
        c_detail = curse[0].ToCharArray();
        npcmat[1] = npcmat[0];
        npcmat[0] = vrClient.cl.getNPCMat();
        n_detail = npcmat[0].ToCharArray();

        NPCMovementStart();

        if (duststorm == 1) // 모바일 플레이어가 폭풍을 일으킴
        {
            // 폭풍 킴
        }
        else
        {
            // 폭풍 끔
        }
        /*
        if (curse[0] != curse[1])
        {
            if (c_detail[0] == '1') // 1번 건물 저주됨
            {

            }
            else if (c_detail[1] == '1') // 2번 건물 저주됨
            {

            }
            else if (c_detail[2] == '1') // 2번 건물 저주됨
            {

            }
            else if (c_detail[3] == '1') // 2번 건물 저주됨
            {

            }
        }
        */
        Debug.Log("Dokkaeibi Life: " + life);
        if (npcmat[0] != npcmat[1])
        {
            if (n_detail[0] != '0') // 1번 npc
            {
                if (n_detail[0] == '1') // 기절
                {
                    npcStunState = 0;
                }
                if (n_detail[0] == '2') // 경고(파란색)
                {
                    
                }
            }
            else if (n_detail[0] == '0')
            {
                // 기본적인 원래 색깔로 되돌리기 (1번 NPC)
            }

            else if (n_detail[1] != '0') // 2번 npc
            {
               
                if (n_detail[1] == '1') // 기절
                {
                    npcStunState = 1;
                }
                if (n_detail[1] == '2') // 경고(파란색)
                {

                }
            }
            else if (n_detail[1] == '0')
            {
                // 기본적인 원래 색깔로 되돌리기 (2번 NPC)
            }

            else if (n_detail[2] != '0') // 3번 npc
            {

                 if (n_detail[2] == '1') // 기절
                 {
                    npcStunState = 2;
                 }
                if (n_detail[2] == '2') // 경고(파란색)
                {

                }
            }
            else if (n_detail[2] == '0')
            {
                // 기본적인 원래 색깔로 되돌리기 (3번 NPC)
            }

            else if (n_detail[3] != '0') // 4번 npc
            {
                if (n_detail[3] == '1') // 기절
                {
                    npcStunState = 3;
                }
                if (n_detail[3] == '2') // 경고(파란색)
                {

                }
            }
            else if (n_detail[3] == '0')
            {
                // 기본적인 원래 색깔로 되돌리기 (4번 NPC)
            }

            else if (n_detail[4] != '0') // 5번 npc
            {
                if (n_detail[4] == '1') // 기절
                {
                    npcStunState = 4;
                }
                if (n_detail[4] == '2') // 경고(파란색)
                {

                }
            }
            else if (n_detail[4] == '0')
            {
                // 기본적인 원래 색깔로 되돌리기 (5번 NPC)
            }

        }
        
    }
    public int GetPropState()
    {
        return prop;
    }
    public int NPCStunState()
    {
        return npcStunState;
    }
    public int CurseDetection()
    {
        int houseToCurse= -1;
        if (curse[0] != curse[1])
        {
            if (c_detail[0] == '1') // 1번 건물 저주됨
            {
                houseToCurse = 0;
            }
            else if (c_detail[1] == '1') // 2번 건물 저주됨
            {
                houseToCurse = 1;
            }
            else if (c_detail[2] == '1') // 2번 건물 저주됨
            {
                houseToCurse = 2;
            }
            else if (c_detail[3] == '1') // 2번 건물 저주됨
            {
                houseToCurse = 3;
            }
        }
        return houseToCurse;
    }
    public bool DustStormInteraction()
    {
        bool dustStormState=false;
        if(duststorm==1)
        {
            dustStormState = true;
        }
        else
        {
            dustStormState = false;
        }
        return dustStormState;
    }
    public bool NPCMovementStart()
    {
        
        if (startNPC == 1)
        {
            vrClient.cl.setVRPos(0);
        }
        else if (startNPC == 3)
        {
            firstStart = true;
        }
        return firstStart;
    }
}
