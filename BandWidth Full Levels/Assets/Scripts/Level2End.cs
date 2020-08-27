using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2End : MonoBehaviour
{
    SceneLoadIn screenFade;
    private AudioManager Audio;
    public GameObject toBeContinued;
    public GameObject thanks1;
    public GameObject thanks2;
    public GameObject thanks3;
    public GameObject thanks4;

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "FPSController" && Input.GetKey("e"))
        {
            this.GetComponent<Animator>().SetBool("isClosing", true);
            screenFade = GameObject.Find("EGO - SceneTransition").GetComponent<SceneLoadIn>();
        }
        if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Done"))
        {
            thanks1.SetActive(true);
            thanks2.SetActive(true);
            thanks3.SetActive(true);
            thanks4.SetActive(true);
            Invoke("onScreenElement", 5);
            Invoke("NextLevel", 10);
        }
    }


    void onScreenElement()
    {
        screenFade.FadeOn();
        toBeContinued.SetActive(true);
    }

    void NextLevel()
    {
        SceneManager.LoadScene(0);
        Audio = GameObject.Find("EGO - AudioManager").GetComponent<AudioManager>();
        Audio.sceneChange = true;
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
        FindObjectOfType<AudioManager>().Stop("Level2");
        FindObjectOfType<AudioManager>().Play("MainMenu");
        OnHoverBorder.singlePickup = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
