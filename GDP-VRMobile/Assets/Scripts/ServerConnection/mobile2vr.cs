using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobile2vr : MonoBehaviour
{
    public static mobile2vr mobileToVRCl;
    public int life, startNPC, prop;
    string[] curse = new string[2];
    string[] npcmat = new string[2];
    char[] c_detail = new char[4];
    char[] n_detail = new char[5];
    int[] dustStorm = new int[2];
    int[] playermat = new int[2];
    public int npcStunState=-1;
    public bool firstStart = false;
    public List<GameObject> NPCList;
    public bool dustStormState = false;
    public bool changePlayerMat = false;
    float time;
    public bool gameOver;
    bool firstStunOne=false;
    bool firstStunTwo = false;
    bool firstStunThree = false;
    bool firstStunFour = false;
    bool firstStunFive = false;
    // Start is called before the first frame update
    private void Awake()
    {
        if (mobileToVRCl && mobileToVRCl != this)
            Destroy(this);
        else
            mobileToVRCl = this;

        gameOver = false;
    }
    void Start()
    {
        dustStorm[0] = vrClient.cl.getDustStrom();
        dustStorm[1] = vrClient.cl.getDustStrom();
        life = vrClient.cl.getLife();
        startNPC = vrClient.cl.getstartNPCMove();
        playermat[0] = vrClient.cl.getPlayerMat();
        playermat[1] = vrClient.cl.getPlayerMat();
        prop = vrClient.cl.getProp();
        curse[0] = vrClient.cl.getCurse();
        curse[1] = vrClient.cl.getCurse();
        npcmat[0] = vrClient.cl.getNPCMat();
        npcmat[1] = vrClient.cl.getNPCMat();
        c_detail = curse[0].ToCharArray();
        n_detail = npcmat[0].ToCharArray();
        vrClient.cl.setTime(300f);
        time = vrClient.cl.getTime();
    }

    // Update is called once per frame
    void Update()
    {
        dustStorm[1] = dustStorm[0];
        dustStorm[0] = vrClient.cl.getDustStrom();
        // dustStorm[1] = vrClient.cl.getDustStrom();
        life = vrClient.cl.getLife();
        startNPC = vrClient.cl.getstartNPCMove();
        playermat[1] = playermat[0];
        playermat[0] = vrClient.cl.getPlayerMat();
        prop = vrClient.cl.getProp();
        //duststorm = vrClient.cl.getDustStrom();
        curse[1] = curse[0];
        curse[0] = vrClient.cl.getCurse();
        c_detail = curse[0].ToCharArray();
        npcmat[1] = npcmat[0];
        npcmat[0] = vrClient.cl.getNPCMat();
        n_detail = npcmat[0].ToCharArray();
        
        time = vrClient.cl.getTime();
        if (vrClient.cl.getstartNPCMove() == 1)
        {
            vrClient.cl.setTime(time - Time.deltaTime);
            if (time <= 0)
            {
                gameOver = true;
                vrClient.cl.setTime(0);
            }
                
        }

        if (playermat[1] != playermat[0])
        {
            if (playermat[0] == 0)
            {
                changePlayerMat = false;
            }
            else
            {
                changePlayerMat = true;
            }
        }

        if (dustStorm[0] != dustStorm[1])
        {
            if (dustStorm[0] == 1) // ����� �÷��̾ ��ǳ�� ����Ŵ
            {
                dustStormState = true;
            }
            else
            {
                dustStormState = false;
                if (dustStorm[0] == 0)
                    vrClient.cl.setDustClean(0);
            }
        }
        
        Debug.Log("Dokkaeibi Life: " + life);
        if (npcmat[0] != npcmat[1])
        {
            if (n_detail[0] != '0') // 1�� npc
            {
                if (n_detail[0] == '1' && firstStunOne==false) // ����
                {
                    NPCList[0].GetComponent<NPCStunHandler>().StunState();
                    firstStunOne = true;
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

            if (n_detail[1] != '0') // 2�� npc
            {
                if (n_detail[1] == '1'&& firstStunTwo==false) // ����
                {
                    NPCList[1].GetComponent<NPCStunHandler>().StunState();
                    firstStunTwo = true;
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

            if (n_detail[2] != '0') // 3�� npc
            {

                if (n_detail[2] == '1'&&firstStunThree == false) // ����
                 {
                    firstStunThree = true;
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

            if (n_detail[3] != '0') // 4�� npc
            {

                if (n_detail[3] == '1' && firstStunFour == false) // ����
                {
                    firstStunFour = true;
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

            if (n_detail[4] != '0') // 5�� npc
            {
              
                if (n_detail[4] == '1'&& firstStunFive==false) // ����
                {
                    firstStunFive = true;
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
        return dustStormState;
    }
    public bool GhostBeingSeen()
    {
       
        return changePlayerMat;
    }
    public bool GameOver()
    {
        return gameOver;
    }
}
