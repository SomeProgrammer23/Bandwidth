using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletImpact : MonoBehaviour
{
    private Transform parent;
    

    void Start()
    {
        parent = GameObject.Find("PlayerHand").transform;
        
    }

    
    void Update()
    {
        if (this.transform.IsChildOf(parent) == false)
        {
            Invoke("DestroyMe", 5f);
        }
        else if (this.transform.IsChildOf(parent))
        {
            CancelInvoke("DestroyMe");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (this.transform.IsChildOf(parent) == false)
        {
            Invoke("DestroyMe", 1f);
        }

        if (collision.collider.name == "FPSController")
        {
            Scene scean = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scean.name);
        }
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }
}
