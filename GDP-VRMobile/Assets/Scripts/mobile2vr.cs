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
            // NPC ������ ����
        }

        if (duststorm == 1) // ����� �÷��̾ ��ǳ�� ����Ŵ
        {
            // ��ǳ Ŵ
        }
        else
        {
            // ��ǳ ��
        }

        if (curse[0] != curse[1])
        {
            if (c_detail[0] == '1') // 1�� �ǹ� ���ֵ�
            {

            }
            else if (c_detail[1] == '1') // 2�� �ǹ� ���ֵ�
            {

            }
            else if (c_detail[2] == '1') // 2�� �ǹ� ���ֵ�
            {

            }
            else if (c_detail[3] == '1') // 2�� �ǹ� ���ֵ�
            {

            }
        }

        if (npcmat[0] != npcmat[1])
        {
            if (n_detail[0] != '0') // 1�� npc
            {
                if (n_detail[0] == '1') // �� �߰�
                {

                }
                else if (n_detail[0] == '2') // ����
                {

                }
            }
            else if (n_detail[1] != '0') // 2�� npc
            {
                if (n_detail[1] == '1') // �� �߰�
                {

                }
                else if (n_detail[1] == '2') // ����
                {

                }
            }
            else if (n_detail[2] != '0') // 3�� npc
            {
                if (n_detail[2] == '1') // �� �߰�
                {

                }
                else if (n_detail[2] == '2') // ����
                {

                }
            }
            else if (n_detail[3] != '0') // 4�� npc
            {
                if (n_detail[3] == '1') // �� �߰�
                {

                }
                else if (n_detail[3] == '2') // ����
                {

                }
            }
            else if (n_detail[4] != '0') // 5�� npc
            {
                if (n_detail[4] == '1') // �� �߰�
                {

                }
                else if (n_detail[4] == '2') // ����
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
