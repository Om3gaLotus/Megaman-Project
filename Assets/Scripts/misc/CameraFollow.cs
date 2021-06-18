using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
   
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Player)
        {

            Vector3 cameraTransform;
            
            cameraTransform = transform.position;

            cameraTransform.x = Player.transform.position.x - 0.5f;
            cameraTransform.x = Mathf.Clamp(cameraTransform.x, -62.2f, 162.5f);
            transform.position = cameraTransform;
        } 
    }
}
