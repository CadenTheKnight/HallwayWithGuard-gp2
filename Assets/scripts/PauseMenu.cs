using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject resumeFirstButton, MainMenuFirstButton, QuitButton; 


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
         AudioListener.pause = false;
        Debug.Log("Resume");
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        AudioListener.pause = true;
        Debug.Log("Pause");
        //clears the selected  game object just in case
        EventSystem.current.SetSelectedGameObject(null);
        //set new selected game object
        EventSystem.current.SetSelectedGameObject(resumeFirstButton);
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
