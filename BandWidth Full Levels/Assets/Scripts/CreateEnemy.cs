using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public GameObject enemy;
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    private bool spawnOnce = true;


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "FPSController" && spawnOnce == true)
        {
            Instantiate(enemy, spawn1.position, spawn1.rotation, transform.parent = spawn1.transform);
            Instantiate(enemy, spawn2.position, spawn2.rotation, transform.parent = spawn2.transform);
            Instantiate(enemy, spawn3.position ,spawn3.rotation, transform.parent = spawn3.transform);
            spawnOnce = false;
        }
    }

}
