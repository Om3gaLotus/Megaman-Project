using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawn : MonoBehaviour
{
    public GameObject[] spawnedObject;

    // Start is called before the first frame update
    void Start()
    {

        int r = Random.Range(0, 2);
        Instantiate(spawnedObject[r], transform.position, transform.rotation);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
