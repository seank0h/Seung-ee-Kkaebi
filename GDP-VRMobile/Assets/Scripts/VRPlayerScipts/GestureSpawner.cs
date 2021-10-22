using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureSpawner : MonoBehaviour
{
    public List<GameObject> prefabs;
    
    public void Spawn(int index){
        Instantiate(prefabs[index], transform.position, transform.rotation);
    }
}
