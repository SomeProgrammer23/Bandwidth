using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadIn : MonoBehaviour
{
    public GameObject screenFadeOut;
    public GameObject screenFadeIn;
    void Start()
    {
        Invoke("FadeOff", 1);
    }

    void FadeOff()
    {
        screenFadeOut.SetActive(false);
    }
    public void FadeOn()
    {
        screenFadeIn.SetActive(true);
    }
}
