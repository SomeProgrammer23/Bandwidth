using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialSwitcher : MonoBehaviour
{

    CharacterControllerTest pickUp;
    TimeManager_01 timeManager;
    public GameObject cam;
    public GameObject tutLookColl;
    public GameObject tutGunColl;
    public GameObject tutTextLook;
    public GameObject tutTextGrab;
    public GameObject tutPanelOne;
    public GameObject tutTextWalk;
    public GameObject tutTextGun;
    public GameObject keepMovingText;
    private bool textOff = false;
    private bool timeSlow = true; 

    // Start is called before the first frame update
    void Start()
    {
        pickUp = GameObject.Find("FPSController").GetComponent<CharacterControllerTest>();
        tutTextGrab.SetActive(true);
        tutTextWalk.SetActive(false);
        Invoke("LookTextOff", 1);
    }

    // Update is called once per frame
    void Update()
    {
        //This switches the tutorials from pickup to walking
        if (pickUp.firstPickup)
        {
            tutTextGrab.SetActive(false);
            tutTextWalk.SetActive(true);
            ReturnTime();
            Invoke("WarningOff", 2);
            


            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                tutPanelOne.SetActive(false);
                
            }
        }
        if (timeSlow == true && textOff == true)
        {
            Time.timeScale = 0;
            Time.fixedDeltaTime = 0;
        }

        //Tutorial RaySwitcher
        RaycastHit switcher;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out switcher))
        {
            if (switcher.collider != tutLookColl.GetComponent<Collider>())
            {
                
                if (textOff == true)
                {
                    tutTextLook.SetActive(false);
                }
            }


            if (switcher.collider == tutGunColl.GetComponent<Collider>())
            {
                Invoke("SwitchOffTV", 2.5f);
            }
        }
    }

    //Returns time to normal once first object gets picked up
    void ReturnTime()
    {
        if (timeSlow == true)
        {
            timeManager = GameObject.Find("EGO - TimeManager").GetComponent<TimeManager_01>();
            timeManager.TutorialSwitch();
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
            timeSlow = false;
            keepMovingText.SetActive(true);
        }
    }

    //Tells player to keep moving (as to not die)
    void WarningOff()
    {
        keepMovingText.SetActive(false);
    }

    //Switches off message on TV
    void SwitchOffTV()
    {
        tutTextGun.SetActive(false);
    }

    //Freezes time on load
    void LookTextOff()
    {
        textOff = true;
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }
}
