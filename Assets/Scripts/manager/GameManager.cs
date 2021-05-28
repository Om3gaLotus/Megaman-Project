using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(SceneManager.GetActiveScene().name == "SampleScene")
            SceneManager.LoadScene(0);
            else if (SceneManager.GetActiveScene().name == "Title Screen")
                SceneManager.LoadScene(1);
            else if (SceneManager.GetActiveScene().name == "GameOver")
                SceneManager.LoadScene(0);
        }
    }
}
