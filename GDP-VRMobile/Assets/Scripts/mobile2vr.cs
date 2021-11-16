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

    // Start is called before the first frame update
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

        if (startNPC == 1)
        {
            mobileClient.cl.setstartNPCMove(2);
        }
        else if (startNPC == 3)
        {
            // NPC 움직임 시작
        }

        if (duststorm == 1) // 모바일 플레이어가 폭풍을 일으킴
        {
            // 폭풍 킴
        }
        else
        {
            // 폭풍 끔
        }

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

        if (npcmat[0] != npcmat[1])
        {
            if (n_detail[0] != '0') // 1번 npc
            {
                if (n_detail[0] == '1') // 적 발견
                {

                }
                else if (n_detail[0] == '2') // 기절
                {

                }
            }
            else if (n_detail[1] != '0') // 2번 npc
            {
                if (n_detail[1] == '1') // 적 발견
                {

                }
                else if (n_detail[1] == '2') // 기절
                {

                }
            }
            else if (n_detail[2] != '0') // 3번 npc
            {
                if (n_detail[2] == '1') // 적 발견
                {

                }
                else if (n_detail[2] == '2') // 기절
                {

                }
            }
            else if (n_detail[3] != '0') // 4번 npc
            {
                if (n_detail[3] == '1') // 적 발견
                {

                }
                else if (n_detail[3] == '2') // 기절
                {

                }
            }
            else if (n_detail[4] != '0') // 5번 npc
            {
                if (n_detail[4] == '1') // 적 발견
                {

                }
                else if (n_detail[4] == '2') // 기절
                {

                }
            }
        }
    }
    public void NPCDetection()
    {

    }
    public void CurseDetection()
    {

    }
    public void DustStormInteraction()
    {

    }
}
