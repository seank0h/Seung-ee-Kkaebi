using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
{
    public GameObject panel;
    public GameObject healthbar;
    public GameObject cursebar;
    public Text end_text;
    float health, curse;

    // Start is called before the first frame update
    void Start()
    {
        health = healthbar.GetComponent<progressLiquid>().getLevel();
        curse = cursebar.GetComponent<progressLiquid>().getLevel();
        
    }

    // Update is called once per frame
    void Update()
    {
        health = healthbar.GetComponent<progressLiquid>().getLevel();
        curse = cursebar.GetComponent<progressLiquid>().getLevel();

        if (health <= 0)
        {
            //defeat
            mobileClient.cl.setstartNPCMove(66);
            end_text.text = "YOU LOSE";
            panel.SetActive(true);
        }
        if (curse >= 103)
        {
            //win
            mobileClient.cl.setstartNPCMove(99);
            end_text.text = "YOU WIN";
            panel.SetActive(true);
        }
    }
}
