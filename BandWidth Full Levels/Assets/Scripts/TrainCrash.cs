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

    void TrainCrashing()
    {
        train.GetComponent<Animator>().SetBool("isCrashing", true);
    }

    public void WallBreak()
    {
        wall.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "FPSController")
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);

        }
    }
}
