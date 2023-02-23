using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    


    void Start()
     {
       
     }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
                
            if (GameIsPaused)
            {
                Resume();
                
            }
            else
            {
                Pause();
                
        {
            }
       
        if (GameIsPaused && pauseMenuUI != null)
            {
            Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            } 
            else
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Debug.Log("Resume");
    }
    void Pause()
    {

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Debug.Log("Pause");
    }
    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
        SceneManager.LoadScene("MainMenu");
    }


    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
