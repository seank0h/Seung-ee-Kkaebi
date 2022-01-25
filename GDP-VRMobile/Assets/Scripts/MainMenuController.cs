using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject clientObject;
    client clientEntity;
    public string serialNumber;
    public GameObject mobilePanel;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(clientObject);
        clientEntity = clientObject.GetComponent<client>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadGameMobile()
    {
        clientEntity.setPortNumber(serialNumber);
        SceneManager.LoadScene("Greybox_mobile");
    }
    public void SetUpGameVR()
    {
       
    }
    public void IncreaseSerialNumber()
    {

    }
    public void ActiveMobileSerialNumberInput()
    {
        mobilePanel.SetActive(true);
    }
    public void  LoadGameVR()
    {
        clientEntity.setPortNumber(serialNumber);
        SceneManager.LoadScene("GreyboxV3-2");
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
            SetUpGameVR();
        }
        if(other.name=="ExitTag")
        {
            Debug.Log("Touching ExitTag");
            QuitGame();
        }
    }
}
