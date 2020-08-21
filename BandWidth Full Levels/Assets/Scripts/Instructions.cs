using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public GameObject instruction;
    public bool isSwitch;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "FPSController")
        {
            if (isSwitch == false)
            {
                
                instruction.SetActive(true);
                Invoke("TextOff", 1);
            }
            if (isSwitch == true)
            {
                instruction.SetActive(true);
                
            }

        }
    }

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
