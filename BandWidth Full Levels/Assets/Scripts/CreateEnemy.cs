using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawns;
    private bool spawnOnce = true;


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "FPSController" && spawnOnce == true)
        {
            for (int i = 0; i < spawns.Length; i++)
            {
                Instantiate(enemy, spawns[i].position, spawns[i].rotation, transform.parent = spawns[i].transform);
            }

            spawnOnce = false;
        }

        
    }

}
