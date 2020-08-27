using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepMovingTextOff : MonoBehaviour
{
    public GameObject keepMovingText;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "FPSController")
        {
            keepMovingText.SetActive(false);

        }
    }
}
