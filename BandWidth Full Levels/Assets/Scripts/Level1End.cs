using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1End : MonoBehaviour
{
    SceneLoadIn screenFade;
    private AudioManager Audio;

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "FPSController" && Input.GetKey("e"))
        {
            this.GetComponent<Animator>().SetBool("isClosing", true);
            screenFade = GameObject.Find("EGO - SceneTransition").GetComponent<SceneLoadIn>();
        }
        if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Done"))
        {
            screenFade.FadeOn();
            Invoke("NextLevel", 1);
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(2);
        Audio = GameObject.Find("EGO - AudioManager").GetComponent<AudioManager>();
        Audio.sceneChange = true;
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
        FindObjectOfType<AudioManager>().Stop("Level1");
        FindObjectOfType<AudioManager>().Play("Level2");
        OnHoverBorder.singlePickup = true;
    }
}
