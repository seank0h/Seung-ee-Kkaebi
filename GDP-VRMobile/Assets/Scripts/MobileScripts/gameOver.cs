using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
{
    public Slider curse_slider;
    public GameObject panel;
    public Text end_text;
    int life;
    float time, curse, start;

    // Start is called before the first frame update
    void Start()
    {
        life = mobileClient.cl.getLife();
        time = mobileClient.cl.getTime();
        curse = curse_slider.value;
        start = 0;
    }

    // Update is called once per frame
    void Update()
    {
        life = mobileClient.cl.getLife();
        time = mobileClient.cl.getTime();
        curse = curse_slider.value;

        if (start <= 3)
            start += Time.deltaTime;
        else
        {
            if (curse >= 99 && time > 0)
            {
                end_text.text = "YOU WIN";
                panel.SetActive(true);
            }
            if (time <= 0 || life <= 0)
            {
                end_text.text = "YOU LOSE";
                panel.SetActive(true);
            }
        }
    }
}
