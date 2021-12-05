using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobile2vr : MonoBehaviour
{
    public static mobile2vr mobileToVRCl;
    int life, startNPC, prop;
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
            if (dustStorm[0] == 1) // 모바일 플레이어가 폭풍을 일으킴
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
            if (n_detail[0] != '0') // 1번 npc
            {
                Debug.Log("1nd NPC COnnection");
                if (n_detail[0] == '1') // 기절
                {
                    Debug.Log("1st NPC Stun");
                    NPCList[0].GetComponent<NPCStunHandler>().StunState();
                }
                if (n_detail[0] == '2') // 경고(파란색)
                {
                    Debug.Log("1st NPC Alert");
                    NPCList[0].GetComponent<NPCAlertHandler>().AlertState();
                }
            }
            else if (n_detail[0] == '0')
            {
                NPCList[0].GetComponent<NPCAlertHandler>().PatrolState();
            }

            if (n_detail[1] != '0') // 2번 npc
            {
                Debug.Log("2nd NPC COnnection");
                if (n_detail[1] == '1') // 기절
                {
                    Debug.Log("2st NPC Stun");
                    NPCList[1].GetComponent<NPCStunHandler>().StunState();
                }
                if (n_detail[1] == '2') // 경고(파란색)
                {
                    Debug.Log("2st NPC Alert");
                    NPCList[1].GetComponent<NPCAlertHandler>().AlertState();
                }
            }
            else if (n_detail[1] == '0')
            {
                NPCList[1].GetComponent<NPCAlertHandler>().PatrolState();
            }

            if (n_detail[2] != '0') // 3번 npc
            {
                Debug.Log("3nd NPC COnnection");
                if (n_detail[2] == '1') // 기절
                 {
                    Debug.Log("3st NPC Stun");
                    NPCList[0].GetComponent<NPCStunHandler>().StunState();
                }
                if (n_detail[2] == '2') // 경고(파란색)
                {
                    Debug.Log("3d NPC Alert");
                    NPCList[2].GetComponent<NPCAlertHandler>().AlertState();
                }
            }
            else if (n_detail[2] == '0')
            {
                NPCList[2].GetComponent<NPCAlertHandler>().PatrolState();
            }

            if (n_detail[3] != '0') // 4번 npc
            {
                Debug.Log("4nd NPC COnnection");
                if (n_detail[3] == '1') // 기절
                {
                    Debug.Log("4st NPC Stun");
                    NPCList[0].GetComponent<NPCStunHandler>().StunState();
                }
                if (n_detail[3] == '2') // 경고(파란색)
                {
                    Debug.Log("4d NPC Alert");
                    NPCList[3].GetComponent<NPCAlertHandler>().AlertState();
                }
            }
            else if (n_detail[3] == '0')
            {
                NPCList[3].GetComponent<NPCAlertHandler>().PatrolState();
            }

            if (n_detail[4] != '0') // 5번 npc
            {
                Debug.Log("5nd NPC COnnection");
                if (n_detail[4] == '1') // 기절
                {
                    Debug.Log("5st NPC Stun");
                    NPCList[4].GetComponent<NPCStunHandler>().StunState();
                }
                if (n_detail[4] == '2') // 경고(파란색)
                {
                    Debug.Log("5st NPC Alert");
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
            Debug.Log("c_detail: " + c_detail[0] + c_detail[1] + c_detail[2] + c_detail[3]);
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
        return dustStormState;
    }
    public bool GhostBeingSeen()
    {
       
        return changePlayerMat;
    }
}
