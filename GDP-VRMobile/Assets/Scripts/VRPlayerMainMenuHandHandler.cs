using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayerMainMenuHandHandler : MonoBehaviour
{
    public GameObject mainMenu;
    MainMenuController menuController;
    public GameObject instructionPanel;
    bool instructionPanelActiveState;
    // Start is called before the first frame update
    void Start()
    {
        menuController = mainMenu.GetComponent<MainMenuController>();
        instructionPanelActiveState = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Triggering");
        if (other.name == "PlayTag")
        {
            Debug.Log("Touching PlayTag");
            menuController.SetUpGameVR();
        }
        if (other.name == "ExitTag")
        {
            Debug.Log("Touching ExitTag");
            menuController.QuitGame();
        }
        if (other.name == "InstructionTag")
        {
            if (instructionPanelActiveState)
            {
                instructionPanel.SetActive(false);
            }
            if (instructionPanelActiveState == false)
            {
                instructionPanel.SetActive(true);
                instructionPanelActiveState = true;
            }
        }
        if (other.name == "IncrementTag")
        {
            
            menuController.ChangeSerialNumber(true);
        }
        if (other.name == "DecrementTag")
        {
            menuController.ChangeSerialNumber(false);
        }
        if (other.name == "EnterGameTag")
        {
            menuController.LoadGameVR();
        }
    }
}
