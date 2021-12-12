using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finaldes : MonoBehaviour
{
    public GameObject curse_bar;
    public Slider gauge;
    public GameObject player;
    float curse, curse_time = 0, distance;
    bool finishing = false;


    // Start is called before the first frame update
    void Start()
    {
        curse = curse_bar.GetComponent<progressLiquid>().getLevel();
        distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        curse = curse_bar.GetComponent<progressLiquid>().getLevel();

        if (distance <=5)
        {
            finishing = true;
        }
        else
        {
            finishing = false;
        }

        Debug.Log("distance : " + distance);
        Debug.Log("finishing : " + finishing);
        Debug.Log("curse : " + curse);
        Debug.Log("curse_time : " + curse_time);

        if (finishing)
        {
            gauge.gameObject.SetActive(true);
            curse_time += Time.deltaTime;
            if (curse_time >= 105)
            {
                curse_time = 105;
                curse_bar.GetComponent<progressLiquid>().increaseLevel(105);
            }
            gauge.value = (curse_time / 105) * 100;

        }
        else
        {
            gauge.gameObject.SetActive(false);
            curse_time = 0;
        }
    }
}
