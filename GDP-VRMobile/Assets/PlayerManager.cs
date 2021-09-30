using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public GameObject mobileManagerObject;
    public MobileManager mobileManagerEntity;
    // Start is called before the first frame update
    void Start()
    {
        mobileManagerEntity = mobileManagerObject.GetComponent<MobileManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
