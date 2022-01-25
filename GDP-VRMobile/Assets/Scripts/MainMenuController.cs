using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Common Main Menu Object")]
    public string serialNumber;
    public Text serialNumberTextUser;
    public static MainMenuController mc;
    //VR Main Menu Objects
    [Header("VR Main Menu Objects")]
    public GameObject playTag;
    public GameObject exitTag;
    public GameObject instructionTag;
    public GameObject enterGameTag;
    public GameObject incrementTag;
    public GameObject decrementTag;
    public Text serialNumberText;

    [Header("Mobile Menu Objects")]
    public GameObject instructionPanel;
    public GameObject mobilePanel;
    public bool instructionPanelStatus;
    int serialNumberInt;
  
    // Start is called before the first frame update
    private void Awake()
    {
        if (mc && mc != this)
            Destroy(this);
        else
            mc = this;
        DontDestroyOnLoad(this.gameObject);
       

    }
    void Start()
    {
        instructionPanelStatus = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OpenSerialInputPanelMobile()
    {
        mobilePanel.SetActive(true);
    }
    public void LoadGameMobile()
    {
       
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
        serialNumberTextUser.text = string.Format("{0:00}", serialNumberInt);
        serialNumber = serialNumberTextUser.text;
        Debug.Log(serialNumberTextUser.text);
       
    }
    public void InputSerialNumberMobile()
    {
        serialNumber = serialNumberTextUser.text;
    }
    public void InstructionPanelActivation()
    {
        if (instructionPanelStatus==false)
        {
            instructionPanelStatus = true;
        }
        else
            instructionPanelStatus = false;

        instructionPanel.SetActive(instructionPanelStatus);
    }
    public void ActiveMobileSerialNumberInput()
    {
        mobilePanel.SetActive(true);
    }
    public void  LoadGameVR()
    {
        //clientEntity.setPortNumber("SIGGRAPH"+serialNumber);
        Debug.Log("SIGGRAPH" + serialNumber);
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
