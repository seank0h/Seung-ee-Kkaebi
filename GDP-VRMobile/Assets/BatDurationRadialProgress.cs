using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatDurationRadialProgress : MonoBehaviour
{
    public GameObject LoadingText;
    public Text ProgressIndicator;
    public Image LoadingBar;
    public bool start;

    private float currentValue;
    public float speed;

    public static BatDurationRadialProgress rp;
    // Start is called before the first frame update
    void Start()
    {
        BatDurationRadialProgress.rp = this;

        speed = 10;
        LoadingBar.fillAmount = 100;
        currentValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentValue >=0 && start)
        {

            currentValue -= speed * Time.deltaTime;
        }
        else if (currentValue <= 0)
        {

            start = false;
            LoadingBar.fillAmount = 100;
            currentValue = 100;
        }

        LoadingBar.fillAmount = currentValue / 100;

    }
    public void startProgress()
    {
        start = true;
    }

    public bool isProgress()
    {
        return start;
    }
}
