using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMethods : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject optionsPanel;
    
    //GameStart Loads and plays game scene 
    public void GameStart()
    {
        FindObjectOfType<AudioManager>().Pause("MainMenu");
        FindObjectOfType<AudioManager>().Play("Level1");
        SceneManager.LoadScene(1);
    }

    //GameExit Quits Game
    public void GameExit()
    {
        Application.Quit();
    }

    //GameOptions opens the options menu
    public void GameOptions()
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    //BackToMenu goes back to menu
    public void BackToMenu()
    {
        mainPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

}
