using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadGameMobile()
    {
        SceneManager.LoadScene("Greybox_mobile");
    }
    public void LoadGameVR()
    {
        SceneManager.LoadScene("GreyboxV3");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Triggering");
        if(other.name=="PlayTag")
        {
            Debug.Log("Touching PlayTag");
            LoadGameVR();
        }
        if(other.name=="ExitTag")
        {
            Debug.Log("Touching ExitTag");
            QuitGame();
        }
    }
}
