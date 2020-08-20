using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private bool textOff = false;
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
        if (pickUp.firstPickup)
        {
            tutTextGrab.SetActive(false);
            tutTextWalk.SetActive(true);
            timeManager = GameObject.Find("EGO - TimeManager").GetComponent<TimeManager_01>();
            timeManager.TutorialSwitch();
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                tutPanelOne.SetActive(false);
            }
        }
        //else
        //{
        //    //timeManager = GameObject.Find("EGO - TimeManager").GetComponent<TimeManager_01>();
        //    //timeManager.SlowTime();
        //}

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
    void SwitchOffTV()
    {
        tutTextGun.SetActive(false);
    }
    void LookTextOff()
    {
        textOff = true;
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }
}
