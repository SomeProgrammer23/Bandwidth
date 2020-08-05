using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject pauseCanvas;
    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Go Go P Key");
            PauseState();
        }
        
    }

    //PauseState uses "P" key to toggle Game Pause
    public void PauseState()
    {
        Debug.Log("PauseState was ");
        if (isPaused == false)
        {
            pauseCanvas.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }
        if (isPaused == true)
        {
            pauseCanvas.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }
    }

    //ResumeGame uses the in-menu button to un-pause
    public void ResumeGame()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    //Jibbity commits one random sinful act that cannot be spoken of on these holy grounds
    public void Jibbity()
    {
        
    }

    //QuitGame does quit the game (presumably)
    public void QuitGame()
    {
        Application.Quit();
    }

    //QuitToMenu quits to menu (thrilling)
    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    //QuitChoose lets you choose the amount of quit you would like to purchase from my store
    public void QuitChoose()
    {

    }
}
