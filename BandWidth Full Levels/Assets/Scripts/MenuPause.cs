using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject godPanel;
    public GameObject pausePanel;
    public GameObject optionPanel;
    public GameObject quitPanel;
    public bool isPaused;
    private AudioManager Audio;
    public GameObject reticle;
    SceneLoadIn screenFade;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        godPanel.SetActive(false);
        pausePanel.SetActive(true);
        optionPanel.SetActive(false);
        quitPanel.SetActive(false);
        //charContAccess = GetComponent<CharacterControllerTest>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Go Go P Key");
            if (isPaused == false)
            {
                Debug.Log("Pause Please");
                PauseGame();
            }
            else if (isPaused == true)
            {
                Debug.Log("UnPause Please");
                ResumeGame();
            }
        }
    }

    //PauseState uses "P" key to Pause game
    public void PauseGame()
    {
        Debug.Log("PauseGame Was called START");
        isPaused = true;
        godPanel.SetActive(true);
        pausePanel.SetActive(true);
        optionPanel.SetActive(false);
        quitPanel.SetActive(false);
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("PauseGame Was called END");
        reticle.SetActive(false);
        FindObjectOfType<AudioManager>().Play("MenuOption");
    }

    //ResumeGame uses the "P key" or in-menu button to un-pause
    public void ResumeGame()
    {
        FindObjectOfType<AudioManager>().Play("MenuOption");
        Debug.Log("ResumeGame Was called START");
        isPaused = false;
        godPanel.SetActive(false);
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("ResumeGame Was called END");
        reticle.SetActive(true);
    }

    //Option commits one random sinful act that cannot be spoken of on these holy grounds
    public void Option()
    {
        FindObjectOfType<AudioManager>().Play("MenuOption");
        Debug.Log("YOU ARE A SINNER");
        pausePanel.SetActive(false);
        optionPanel.SetActive(true);
    }

    //QuitGame does quit the game (presumably)
    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("MenuOption");
        Debug.Log("YOU HAVE CANCELLED EXISTENCE");
        Application.Quit();
    }

    //QuitToMenu quits to menu (thrilling)
    public void QuitToMenu()
    {
        FindObjectOfType<AudioManager>().Play("MenuOption");
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
        screenFade = GameObject.Find("EGO - SceneTransition").GetComponent<SceneLoadIn>();
        screenFade.FadeOn();
        OnHoverBorder.singlePickup = true;
        Invoke("QuitLevel",1);
    }

    void QuitLevel()
    {
        Debug.Log("You have purchased Later");
        FindObjectOfType<AudioManager>().Play("MainMenu");
        FindObjectOfType<AudioManager>().Stop("Level1");
        FindObjectOfType<AudioManager>().Stop("Level2");
        FindObjectOfType<AudioManager>().Stop("Level3");
        FindObjectOfType<AudioManager>().Stop("Level4");
        SceneManager.LoadScene(0);
        Audio = GameObject.Find("EGO - AudioManager").GetComponent<AudioManager>();
        Audio.sceneChange = true;
    }

    //QuitChoose lets you choose the amount of quit you would like to purchase from my store
    public void QuitChoose()
    {
        FindObjectOfType<AudioManager>().Play("MenuOption");
        Debug.Log("Welcome to Choosi");
        pausePanel.SetActive(false);
        quitPanel.SetActive(true);
    }

    //BackToMenu undoes your choices if you happen to make a stupid click desicion
    public void BackToMenu()
    {
        FindObjectOfType<AudioManager>().Play("MenuOption");
        Debug.Log("Le Repause");
        pausePanel.SetActive(true);
        optionPanel.SetActive(false);
        quitPanel.SetActive(false);

    }
}
