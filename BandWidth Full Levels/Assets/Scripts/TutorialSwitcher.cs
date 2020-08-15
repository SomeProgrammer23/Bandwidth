using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSwitcher : MonoBehaviour
{

    CharacterControllerTest pickUp;
    public GameObject tutTextOne;
    public GameObject tutTextTwo;
    // Start is called before the first frame update
    void Start()
    {
        pickUp = GameObject.Find("FPSController").GetComponent<CharacterControllerTest>();
        tutTextOne.SetActive(true);
        tutTextTwo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUp.firstPickup)
        {
            tutTextOne.SetActive(false);
            tutTextTwo.SetActive(true);
        }

    }
}
