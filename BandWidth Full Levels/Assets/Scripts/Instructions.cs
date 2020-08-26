using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public GameObject instruction;
    public bool isSwitch;
    private bool displayOnce = false;


    //Shows Instructions when situated in a trigger
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "FPSController")
        {
            if (isSwitch == false && displayOnce == false)
            {
                
                instruction.SetActive(true);
                Invoke("TextOff", 1);
                displayOnce = true;
            }
            if (isSwitch == true && displayOnce == false)
            {
                instruction.SetActive(true);
                displayOnce = true;
            }

        }
    }

    //Closes Instruction Based on particular key input
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "FPSController")
        {
            if (isSwitch == true)
            {
                if (Input.GetKey("e"))
                {
                    instruction.SetActive(false);
                    Destroy(this);
                }
            }
        }
        
    }
    //Closes Instruction when leaving a trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "FPSController")
        {
            if (isSwitch == true)
            {
                instruction.SetActive(false);
            }
        }
    }

    void TextOff()
    {
        instruction.SetActive(false);
    }
}
