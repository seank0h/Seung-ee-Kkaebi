using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CharacterSwap : MonoBehaviour
{
    public Transform currCharacter;
    public List<Transform> possibleCharacters;
    public int whichCharacter;
    public CinemachineVirtualCamera cam;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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
}
