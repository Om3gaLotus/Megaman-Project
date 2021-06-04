using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{

 



  

    void Update()
    {
        
    }

    public void StartGame()
    {
      
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {


    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();

    }

}
