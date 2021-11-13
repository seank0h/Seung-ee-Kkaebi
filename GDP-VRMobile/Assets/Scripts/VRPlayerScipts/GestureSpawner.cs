using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureSpawner : MonoBehaviour
{
    [Header("SpawnTransform")]
    // Transform where the bat have to be Instantiated
    public Transform hand;

    [Header("BulletPrefab")]
    // GameObject used as bat to Instantiate
    public GameObject bat;

    public void OnActivate(){
        Debug.Log("BAT is activated!!!");
        bat.SetActive(true);
    }
    public void Inactivate(){
        Debug.Log("BAT is inactivated***");
        bat.SetActive(false);
    }
}
