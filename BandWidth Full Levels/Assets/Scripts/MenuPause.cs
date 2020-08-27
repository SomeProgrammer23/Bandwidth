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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                PauseGame();
            }
            else if (isPaused == true)
            {
                ResumeGame();
            }
        }
    }

    //PauseState uses "P" key or "ESC" to Pause game
    public void PauseGame()
    {
        screenFade = GameObject.Find("EGO - SceneTransition").GetComponent<SceneLoadIn>();
        if (screenFade.transitionFinish == true)
        {
            isPaused = true;
            godPanel.SetActive(true);
            pausePanel.SetActive(true);
            optionPanel.SetActive(false);
            quitPanel.SetActive(false);
            Time.timeScale = 0;
            Time.fixedDeltaTime = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            reticle.SetActive(false);
            FindObjectOfType<AudioManager>().Play("MenuOption");
        }
    }

    //ResumeGame uses the "P" / "ESC" key or in-menu button to un-pause
    public void ResumeGame()
    {
        FindObjectOfType<AudioManager>().Play("MenuOption");
        isPaused = false;
        godPanel.SetActive(false);
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        reticle.SetActive(true);
    }

    //Option opens an options menu (called with button click)
    public void Option()
    {
        FindObjectOfType<AudioManager>().Play("MenuOption");
        pausePanel.SetActive(false);
        optionPanel.SetActive(true);
    }

    //QuitGame quits to desktop (called with button click)
    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("MenuOption");
        Application.Quit();
    }

    //QuitToMenu quits to menu (called with button click)
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
        FindObjectOfType<AudioManager>().Play("MainMenu");
        FindObjectOfType<AudioManager>().Stop("Level1");
        FindObjectOfType<AudioManager>().Stop("Level2");
        FindObjectOfType<AudioManager>().Stop("Level3");
        FindObjectOfType<AudioManager>().Stop("Level4");
        SceneManager.LoadScene(0);
        Audio = GameObject.Find("EGO - AudioManager").GetComponent<AudioManager>();
        Audio.sceneChange = true;
    }

    //QuitChoose bring up the option to choose to quit to menu or to desktop (called with button click)
    public void QuitChoose()
    {
        FindObjectOfType<AudioManager>().Play("MenuOption");
        pausePanel.SetActive(false);
        quitPanel.SetActive(true);
    }

    //BackToMenu takes you to the previous menu (called with button click)
    public void BackToMenu()
    {
        FindObjectOfType<AudioManager>().Play("MenuOption");
        pausePanel.SetActive(true);
        optionPanel.SetActive(false);
        quitPanel.SetActive(false);
    }
}
