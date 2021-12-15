using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class gameOver : MonoBehaviour
{
    public GameObject panel;
    public GameObject healthbar;
    public GameObject cursebar;
    public GameObject player;
    public RawImage Kkaebi, Seung_ee;
    public Button status;
    float health, curse;
    bool first = true;
    ThirdPersonController playecon;

    // Start is called before the first frame update
    void Start()
    {
        health = healthbar.GetComponent<progressLiquid>().getLevel();
        curse = cursebar.GetComponent<progressLiquid>().getLevel();
        playecon = player.GetComponent<ThirdPersonController>();

    }

    // Update is called once per frame
    void Update()
    {
        health = healthbar.GetComponent<progressLiquid>().getLevel();
        curse = cursebar.GetComponent<progressLiquid>().getLevel();

        if (health <= 1)
        {
            //defeat
            if (first)
            {
                playecon.MoveSpeed = 0;
                status.gameObject.SetActive(false);
                mobileClient.cl.setstartNPCMove(66);
                panel.SetActive(true);
                Seung_ee.gameObject.SetActive(true);
                Vibration.Vibrate(3000);
                first = false;
            }
        }
        if (curse >= 103)
        {
            //win
            if (first)
            {
                Invoke("Kkaebi_win", 3f);
            }
        }
    }

    void Kkaebi_win()
    {
        status.gameObject.SetActive(false);
        mobileClient.cl.setstartNPCMove(99);
        panel.SetActive(true);
        Kkaebi.gameObject.SetActive(true);
        Vibration.Vibrate(3000);
        first = false;
    }
}
