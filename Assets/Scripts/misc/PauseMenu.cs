using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class PauseMenu : MonoBehaviour
{

    public static bool GamePause = false;

    public GameObject pauseMenuUI;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (GamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume ()
    {
        GetComponent <playermovement> ().enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePause = false;
    }

    void Pause()
    {
        GetComponent<playermovement>().enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePause = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();

    }
}
