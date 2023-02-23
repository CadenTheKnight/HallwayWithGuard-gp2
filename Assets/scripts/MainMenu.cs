using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class MainMenu : MonoBehaviour
{
    public GameObject HowToPlayMenu, CreditsMenu, MainMenuUi;

    public GameObject PlayFirstButton, HowToPlayFirstButton, CreditsFirstButton, QuitToMenuButton, QuitToMenuButton2;
    void Update()

    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void OpenHowToPlayMenu()
    {
        HowToPlayMenu.SetActive(true);
        MainMenuUi.SetActive(false);
        //clears selected button
        EventSystem.current.SetSelectedGameObject(null);
        //selects the button
        EventSystem.current.SetSelectedGameObject(QuitToMenuButton);
    }
    public void OpenCreditsMenu()
    {
        CreditsMenu.SetActive(true);
        MainMenuUi.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        //selects the button
        EventSystem.current.SetSelectedGameObject(QuitToMenuButton2);
    }
    public void CloseHowToPlay()
    {
        HowToPlayMenu.SetActive(false);
        MainMenuUi.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        //selects the button
        EventSystem.current.SetSelectedGameObject(HowToPlayFirstButton);
    }
    public void CloseCreditsButton()
    {
        CreditsMenu.SetActive(false);
        MainMenuUi.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        //selects the button
        EventSystem.current.SetSelectedGameObject(CreditsFirstButton);
    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}    

