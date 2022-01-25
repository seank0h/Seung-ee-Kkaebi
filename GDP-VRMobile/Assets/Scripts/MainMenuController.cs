using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject clientObject;
    client clientEntity;
    public string serialNumber;
    public GameObject mobilePanel;

    //VR Main Menu Objects
    public GameObject playTag;
    public GameObject exitTag;
    public GameObject instructionTag;
    public GameObject enterGameTag;
    public GameObject incrementTag;
    public GameObject decrementTag;

  
    public Text serialNumberText;
    public Text serialNumberTextUser;
    int serialNumberInt;
  
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
        playTag.SetActive(false);
        exitTag.SetActive(false);
        instructionTag.SetActive(false);
        serialNumberText.gameObject.SetActive(true);
        incrementTag.SetActive(true);
        decrementTag.SetActive(true);
        enterGameTag.SetActive(true);
    }
    public void InputSerialNumber()
    {
        serialNumberTextUser.text = serialNumberInt.ToString();
        serialNumber = serialNumberTextUser.text;
       
    }
    public void ActiveMobileSerialNumberInput()
    {
        mobilePanel.SetActive(true);
    }
    public void  LoadGameVR()
    {
        clientEntity.setPortNumber(serialNumber);
        SceneManager.LoadScene("GreyboxV3");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ChangeSerialNumber(bool increment)
    {
        Debug.Log("incrementing number");
        if(increment)
        {
            if(serialNumberInt!=15)
            {
                serialNumberInt += 1;
            }
           
        }
        else
        {
            if(serialNumberInt !=0)
            {
                serialNumberInt -= 1;
            }
          
        }
        InputSerialNumber();
    }
    //Only for VR
   
}
