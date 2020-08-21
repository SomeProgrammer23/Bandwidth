using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMethods : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject optionsPanel;
    public GameObject levelStartPanel;
    private AudioManager Audio;
    SceneLoadIn ScreenFade;

    private void Start()
    {
        mainPanel.SetActive(true);
        optionsPanel.SetActive(false);
        levelStartPanel.SetActive(false);
    }

    //GameStart Loads and plays game scene 
    public void GameStartOne()
    {
        FindObjectOfType<AudioManager>().Play("MenuOption");
        Invoke("LevelOneStart", 1);
        ScreenFade = GameObject.Find("EGO - SceneTransition").GetComponent<SceneLoadIn>();
        ScreenFade.FadeOn();
    }

    public void GameStartTwo()
    {
        FindObjectOfType<AudioManager>().Play("MenuOption");
        Invoke("LevelTwoStart", 1);
        ScreenFade = GameObject.Find("EGO - SceneTransition").GetComponent<SceneLoadIn>();
        ScreenFade.FadeOn();
    }

    public void GameStartThree()
    {
        FindObjectOfType<AudioManager>().Play("MenuOption");
        Invoke("LevelThreeStart", 1);
        ScreenFade = GameObject.Find("EGO - SceneTransition").GetComponent<SceneLoadIn>();
        ScreenFade.FadeOn();
    }

    public void GameStartFour()
    {
        FindObjectOfType<AudioManager>().Play("MenuOption");
        Invoke("LevelFourStart", 1);
        ScreenFade = GameObject.Find("EGO - SceneTransition").GetComponent<SceneLoadIn>();
        ScreenFade.FadeOn();
    }

    //GameExit Quits Game
    public void GameExit()
    {
        FindObjectOfType<AudioManager>().Play("MenuOption");
        Application.Quit();
    }

    //GameOptions opens the options menu
    public void GameOptions()
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(true);
        FindObjectOfType<AudioManager>().Play("MenuOption");
    }

    //BackToMenu goes back to menu
    public void BackToMenu()
    {
        mainPanel.SetActive(true);
        optionsPanel.SetActive(false);
        levelStartPanel.SetActive(false);
        FindObjectOfType<AudioManager>().Play("MenuOption");
    }

    //StartGame opens the Level Select panel
    public void StartGame()
    {
        mainPanel.SetActive(false);
        levelStartPanel.SetActive(true);
        FindObjectOfType<AudioManager>().Play("MenuOption");
    }
    
    //LevelOneStart starts the game from the beginning
    void LevelOneStart()
    {
        Debug.Log("LevelOneStart");
        FindObjectOfType<AudioManager>().Stop("MainMenu");
        FindObjectOfType<AudioManager>().Play("Level1");
        SceneManager.LoadScene(1);
        Audio = GameObject.Find("EGO - AudioManager").GetComponent<AudioManager>();
        Audio.sceneChange = true;
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
    }

    //LevelTwoStart starts you from the beginning of the second level
    void LevelTwoStart()
    {
        Debug.Log("LevelTwoStart");
        FindObjectOfType<AudioManager>().Stop("MainMenu");
        FindObjectOfType<AudioManager>().Play("Level2");
        SceneManager.LoadScene(2);
        Audio = GameObject.Find("EGO - AudioManager").GetComponent<AudioManager>();
        Audio.sceneChange = true;
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
    }

    //LevelThreeStart starts you from the beginning of the third level
    void LevelThreeStart()
    {
        Debug.Log("LevelThreeStart");
        FindObjectOfType<AudioManager>().Stop("MainMenu");
        FindObjectOfType<AudioManager>().Play("Level3");
        SceneManager.LoadScene(3);
        Audio = GameObject.Find("EGO - AudioManager").GetComponent<AudioManager>();
        Audio.sceneChange = true;
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
    }

    //LevelFourStart start you from the checkpoint in the third level
    void LevelFourStart()
    {

    }
}
