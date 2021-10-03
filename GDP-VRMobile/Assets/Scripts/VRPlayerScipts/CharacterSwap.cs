using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
public class CharacterSwap : MonoBehaviour
{
    public Transform currCharacter;
    public List<Transform> possibleCharacters;
    public int whichCharacter;
    public CinemachineVirtualCamera cam;
    //Mobile Camera Test
    public CinemachineVirtualCamera isoCam;
    public Transform mobileCharacterTest;
    [SerializeField]
    private bool mobileSwapCalled;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private InputAction action;

    /*
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    */
    void Start()
    {
        action.performed += _ => MobileCharacterTestSwap();
    }

    private void OnEnable()
    {
        action.Enable();
    }
    private void OnDisable()
    {
        action.Disable();
    }
    public void CharacterSwitchLeft()
    {
        if(whichCharacter== 0)
        {
            whichCharacter = possibleCharacters.Count - 1;
        }
        else
        {
            whichCharacter -= 1;
        }
        Swap();
    }
    public void CharacterSwitchRight()
    {
        if (whichCharacter == possibleCharacters.Count - 1)
        {
            whichCharacter = 0;
        }
        else
        {
            whichCharacter += 1;
        }
        Swap();
    }
    void Swap()
    {
       
        currCharacter = possibleCharacters[whichCharacter];
        currCharacter.gameObject.SetActive(true);
        Debug.Log("Swap Called");
        for (int i = 0; i < possibleCharacters.Count; i++)
        {
            if(possibleCharacters[i] !=currCharacter)
            {
                possibleCharacters[i].gameObject.SetActive(false);
            }
        }
        cam.Follow = currCharacter.Find("PlayerCameraRoot");
        //cam.LookAt = currCharacter.Find("PlayerCameraRoot");
    }
    public void MobileCharacterTestSwap()
    {
        if(mobileSwapCalled)
        {
            animator.Play("MobileCharacterTestCameraState");
            currCharacter.gameObject.SetActive(false);
            //isoCam.Follow = mobileCharacterTest;
            
        }
        else
        {
            animator.Play("VRCameraState");
            currCharacter.gameObject.SetActive(true);
            
        }
        mobileSwapCalled = !mobileSwapCalled;
    }
}
