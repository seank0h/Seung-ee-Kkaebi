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
    public List<GameObject> NPCList;

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

        if (duststorm == 1) // ����� �÷��̾ ��ǳ�� ����Ŵ
        {
            // ��ǳ Ŵ
        }
        else
        {
            // ��ǳ ��
        }
        /*
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
        */
        Debug.Log("Dokkaeibi Life: " + life);
        if (npcmat[0] != npcmat[1])
        {
            if (n_detail[0] != '0') // 1�� npc
            {
                if (n_detail[0] == '1') // ����
                {
                    NPCList[0].GetComponent<NPCStunHandler>().StunState();
                }
                if (n_detail[0] == '2') // ���(�Ķ���)
                {
                    NPCList[0].GetComponent<NPCAlertHandler>().AlertState();
                }
            }
            else if (n_detail[0] == '0')
            {
                NPCList[0].GetComponent<NPCAlertHandler>().PatrolState();
            }

            else if (n_detail[1] != '0') // 2�� npc
            {
               
                if (n_detail[1] == '1') // ����
                {
                    NPCList[1].GetComponent<NPCStunHandler>().StunState();
                }
                if (n_detail[1] == '2') // ���(�Ķ���)
                {
                    NPCList[1].GetComponent<NPCAlertHandler>().AlertState();
                }
            }
            else if (n_detail[1] == '0')
            {
                NPCList[1].GetComponent<NPCAlertHandler>().PatrolState();
            }

            else if (n_detail[2] != '0') // 3�� npc
            {

                 if (n_detail[2] == '1') // ����
                 {
                    NPCList[0].GetComponent<NPCStunHandler>().StunState();
                }
                if (n_detail[2] == '2') // ���(�Ķ���)
                {
                    NPCList[2].GetComponent<NPCAlertHandler>().AlertState();
                }
            }
            else if (n_detail[2] == '0')
            {
                NPCList[2].GetComponent<NPCAlertHandler>().PatrolState();
            }

            else if (n_detail[3] != '0') // 4�� npc
            {
                if (n_detail[3] == '1') // ����
                {
                    NPCList[0].GetComponent<NPCStunHandler>().StunState();
                }
                if (n_detail[3] == '2') // ���(�Ķ���)
                {
                    NPCList[3].GetComponent<NPCAlertHandler>().AlertState();
                }
            }
            else if (n_detail[3] == '0')
            {
                NPCList[3].GetComponent<NPCAlertHandler>().PatrolState();
            }

            else if (n_detail[4] != '0') // 5�� npc
            {
                if (n_detail[4] == '1') // ����
                {
                    NPCList[4].GetComponent<NPCStunHandler>().StunState();
                }
                if (n_detail[4] == '2') // ���(�Ķ���)
                {
                    NPCList[4].GetComponent<NPCAlertHandler>().AlertState();
                }
            }
            else if (n_detail[4] == '0')
            {
                NPCList[4].GetComponent<NPCAlertHandler>().PatrolState();
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
            if (c_detail[0] == '1') // 1�� �ǹ� ���ֵ�
            {
                houseToCurse = 0;
            }
            else if (c_detail[1] == '1') // 2�� �ǹ� ���ֵ�
            {
                houseToCurse = 1;
            }
            else if (c_detail[2] == '1') // 2�� �ǹ� ���ֵ�
            {
                houseToCurse = 2;
            }
            else if (c_detail[3] == '1') // 2�� �ǹ� ���ֵ�
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
