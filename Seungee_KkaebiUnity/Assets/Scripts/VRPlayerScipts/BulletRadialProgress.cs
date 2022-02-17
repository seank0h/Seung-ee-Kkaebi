using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletRadialProgress : MonoBehaviour
{
	public GameObject LoadingText;
	public Text ProgressIndicator;
	public Image LoadingBar;
	public bool start;

	private float currentValue;
	public float speed;

	public static BulletRadialProgress rp;


	// Use this for initialization
	void Start()
	{
		BulletRadialProgress.rp = this;

		speed = 180;
		LoadingBar.fillAmount = 0;
		currentValue = 0;
	}

	// Update is called once per frame
	void Update()
	{
		if (currentValue < 100 && start)
		{
			ProgressIndicator.text = "Flare Cooldown";
			currentValue += speed * Time.deltaTime;
		}
		else if (currentValue > 100)
		{
			ProgressIndicator.text = "Ready To Fire Flare";
			start = false;
			LoadingBar.fillAmount = 0;
			currentValue = 0;
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
