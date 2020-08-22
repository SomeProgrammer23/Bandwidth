using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainCrash : MonoBehaviour
{
    public GameObject train;
    public GameObject wall;
    void Start()
    {
        Invoke("TrainCrashing", 5);
    }

    void TrainCrashing()
    {
        train.GetComponent<Animator>().SetBool("isCrashing", true);
    }

    public void WallBreak()
    {
        wall.SetActive(false);
    }
}
