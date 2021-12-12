using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class generateWall : MonoBehaviour
{
    public GameObject opticArea;
    public float rad = 1.5f;
    public float maxHeight = 5.0f;

    public bool randomMove;

    public string sphereTag;


    // for tracking properties change
    private Vector3 _extents;
    private int _sphereCount;
    private float _sphereSize;

    /// <summary>
    ///     How far to place spheres randomly.
    /// </summary>
    public Vector3 Extents;

    /// <summary>
    ///     How many spheres wanted.
    /// </summary>
    public int SphereCount;

    public float SphereSize;

    private void OnValidate(){
        // prevent wrong values to be entered
        Extents = new Vector3(Mathf.Max(0.0f, Extents.x), Mathf.Max(0.0f, Extents.y), Mathf.Max(0.0f, Extents.z));
        SphereCount = Mathf.Max(0, SphereCount);
        SphereSize = Mathf.Max(0.0f, SphereSize);
    }

    private void Reset(){
        Extents = new Vector3(250.0f, 20.0f, 250.0f);
        SphereCount = 100;
        SphereSize = 20.0f;
    }

    void Start(){
        //opticArea = GameObject.FindWithTag("visStim");
        UpdateSpheres();
    }


    void Update(){
        //UpdateSpheres();
    }


    private void UpdateSpheres(){
        if (Extents == _extents && SphereCount == _sphereCount && Mathf.Approximately(SphereSize, _sphereSize))
            return;

        // cleanup
        var spheres = GameObject.FindGameObjectsWithTag(sphereTag);
        foreach (var t in spheres){
            if (Application.isEditor){
                DestroyImmediate(t);
            }else{
                Destroy(t);
            }
        }

        //Generate Optics
        if(randomMove){
            for (var i = 0; i < SphereCount; i++){
                var center = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                center.tag = sphereTag;
                center.transform.SetParent(opticArea.transform);
                center.transform.localScale = new Vector3(SphereSize, SphereSize, SphereSize);
                center.GetComponent<Renderer>().enabled = false;

                var o = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                o.tag = sphereTag;
                o.transform.SetParent(center.transform);
                o.transform.localScale = new Vector3(1, 1, 1);
                
                // get random position
                var angle = Random.Range(0, 360);
                var x = Mathf.Cos(angle) * rad;
                var y = Random.Range(0.5f, maxHeight);
                var z = Mathf.Sin(angle) * rad;

                // place !
                center.transform.position = new Vector3(0, y, 0);
                o.transform.position = new Vector3(x, y, z);
            }


        }else{
            for (var i = 0; i < SphereCount; i++){
                var o = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                o.tag = sphereTag;

                o.transform.SetParent(opticArea.transform);
                o.transform.localScale = new Vector3(SphereSize, SphereSize, SphereSize);
                o.GetComponent<Renderer>().enabled = true;
                
                o.AddComponent<Rigidbody>();
                o.GetComponent<Rigidbody>().isKinematic = true;
                o.GetComponent<Rigidbody>().useGravity = false;
                o.GetComponent<Rigidbody>().mass = 10000;

                // get random position
                var angle = Random.Range(0, 360);
                var x = Mathf.Cos(angle) * rad;
                var y = Random.Range(0.5f, maxHeight);
                var z = Mathf.Sin(angle) * rad;

                // place !
                o.transform.position = new Vector3(x, y, z);
            }
        }

        _extents = Extents;
        _sphereCount = SphereCount;
        _sphereSize = SphereSize;
    }
}
