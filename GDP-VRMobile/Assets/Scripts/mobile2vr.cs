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
        life = mobileClient.cl.getLife();
        startNPC = mobileClient.cl.getstartNPCMove();
        playermat = mobileClient.cl.getPlayerMat();
        prop = mobileClient.cl.getProp();
        duststorm = mobileClient.cl.getDustStrom();
        curse[0] = mobileClient.cl.getCurse();
        curse[1] = mobileClient.cl.getCurse();
        npcmat[0] = mobileClient.cl.getNPCMat();
        npcmat[1] = mobileClient.cl.getNPCMat();
        c_detail = curse[0].ToCharArray();
        n_detail = npcmat[0].ToCharArray();
    }

    // Update is called once per frame
    void Update()
    {
        life = mobileClient.cl.getLife();
        startNPC = mobileClient.cl.getstartNPCMove();
        playermat = mobileClient.cl.getPlayerMat();
        prop = mobileClient.cl.getProp();
        duststorm = mobileClient.cl.getDustStrom();
        curse[1] = curse[0];
        curse[0] = mobileClient.cl.getCurse();
        c_detail = curse[0].ToCharArray();
        npcmat[1] = npcmat[0];
        npcmat[0] = mobileClient.cl.getNPCMat();
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
        if (npcmat[0] != npcmat[1])
        {
            if (n_detail[0] != '0') // 1번 npc
            {
                 if (n_detail[0] == '2') // 기절
                 {
                    npcStunState = 0;
                 }
            }
            else if (n_detail[1] != '0') // 2번 npc
            {
               
                 if (n_detail[1] == '2') // 기절
                 {
                    npcStunState = 1;
                 }
            }
            else if (n_detail[2] != '0') // 3번 npc
            {

                 if (n_detail[2] == '2') // 기절
                 {
                    npcStunState = 2;
                 }
            }
            else if (n_detail[3] != '0') // 4번 npc
            {
                   if (n_detail[3] == '2') // 기절
                    {
                       npcStunState = 3;
                    }
            }
            else if (n_detail[4] != '0') // 5번 npc
            {
                     if (n_detail[4] == '2') // 기절
                     {
                       npcStunState = 4;
                     }
            }
        
        }
        
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
