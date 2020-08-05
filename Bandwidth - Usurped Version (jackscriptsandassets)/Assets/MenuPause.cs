using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject pauseCanvas;
    public bool isPaused;
    CharacterControllerTest charContAccess;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        pauseCanvas.SetActive(false);
        charContAccess = GetComponent<CharacterControllerTest>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
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
        isPaused = true;
        charContAccess.CameraDiddle();
        pauseCanvas.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("PauseGame Was called");
    }

    //ResumeGame uses the "P key" or in-menu button to un-pause
    public void ResumeGame()
    {
        isPaused = false;
        charContAccess.CameraDiddle();
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("ResumeGame Was called");
    }

    //Jibbity commits one random sinful act that cannot be spoken of on these holy grounds
    public void Jibbity()
    {
        Debug.Log("YOU ARE A SINNER");
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
