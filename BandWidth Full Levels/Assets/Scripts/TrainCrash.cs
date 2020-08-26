using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainCrash : MonoBehaviour
{
    public GameObject train;
    public GameObject wall;
    void Start()
    {
        Invoke("TrainCrashing", 10);
    }

    //This makes the train in level 2 crash, allowing players to progress
    void TrainCrashing()
    {
        train.GetComponent<Animator>().SetBool("isCrashing", true);
    }

    //This breaks the wall that blocks progress
    public void WallBreak()
    {
        wall.SetActive(false);
    }

    //This kill players if the get hit by the train
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "FPSController")
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);

        }
    }
}
