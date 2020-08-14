using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject godPanel;
    public GameObject pausePanel;
    public GameObject jibbityPanel;
    public GameObject quitPanel;
    public bool isPaused;
    
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        godPanel.SetActive(false);
        pausePanel.SetActive(true);
        jibbityPanel.SetActive(false);
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
        jibbityPanel.SetActive(false);
        quitPanel.SetActive(false);
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("PauseGame Was called END");
    }

    //ResumeGame uses the "P key" or in-menu button to un-pause
    public void ResumeGame()
    {
        Debug.Log("ResumeGame Was called START");
        isPaused = false;
        godPanel.SetActive(false);
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("ResumeGame Was called END");
    }

    //Jibbity commits one random sinful act that cannot be spoken of on these holy grounds
    public void Jibbity()
    {
        Debug.Log("YOU ARE A SINNER");
        pausePanel.SetActive(false);
        jibbityPanel.SetActive(true);
    }

    //QuitGame does quit the game (presumably)
    public void QuitGame()
    {
        Debug.Log("YOU HAVE CANCELLED EXISTENCE");
        Application.Quit();
    }

    //QuitToMenu quits to menu (thrilling)
    public void QuitToMenu()
    {
        Debug.Log("You have purchased Later");
        FindObjectOfType<AudioManager>().Play("MainMenu");
        FindObjectOfType<AudioManager>().Pause("Level1");
        SceneManager.LoadScene(0);
    }

    //QuitChoose lets you choose the amount of quit you would like to purchase from my store
    public void QuitChoose()
    {
        Debug.Log("Welcome to Choosi");
        pausePanel.SetActive(false);
        quitPanel.SetActive(true);
    }

    //BackToMenu undoes your choices if you happen to make a stupid click desicion
    public void BackToMenu()
    {
        Debug.Log("Le Repause");
        pausePanel.SetActive(true);
        jibbityPanel.SetActive(false);
        quitPanel.SetActive(false);

    }
}
