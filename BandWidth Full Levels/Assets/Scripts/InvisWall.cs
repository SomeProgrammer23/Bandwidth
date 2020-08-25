using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisWall : MonoBehaviour
{
    public GameObject elevator;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "FPSController")
        {
            this.GetComponent<Collider>().enabled = true;
            elevator.GetComponent<Animator>().SetBool("isWorking", true);
        }
    }
}
