using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMethods : MonoBehaviour
{
    
    public void GameStart()
    {
        FindObjectOfType<AudioManager>().Pause("MainMenu");
        FindObjectOfType<AudioManager>().Play("Level1");
        SceneManager.LoadScene(1);
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void GameFlibbity()
    {

    }

}
