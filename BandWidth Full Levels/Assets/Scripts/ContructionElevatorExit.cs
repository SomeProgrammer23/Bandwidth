using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContructionElevatorExit : MonoBehaviour
{
    SceneLoadIn screenFade;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "FPSController")
        {
            Invoke("NextLevel", 1);
            screenFade = GameObject.Find("EGO - SceneTransition").GetComponent<SceneLoadIn>();
            screenFade.FadeOn();
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(3);
    }
}
