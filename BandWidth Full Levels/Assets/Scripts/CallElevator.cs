using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallElevator : MonoBehaviour
{
    public GameObject elevator;

    //Calls elevator to progress to second level
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "FPSController" && Input.GetKey("e"))
        {
            elevator.GetComponent<Animator>().SetBool("isOpening", true);

        }
    }
}
