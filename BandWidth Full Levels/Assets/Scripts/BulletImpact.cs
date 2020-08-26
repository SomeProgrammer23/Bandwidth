using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletImpact : MonoBehaviour
{
    private Transform parent;
    private OnHoverBorder OnHoverBorder;


    void Start()
    {
        parent = GameObject.Find("PlayerHand").transform;
        
    }

    
    void Update()
    {
        //Detects whether a Bullet is being held, and deletes bullet after five seconds of not being held
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
        //If bullet is not held, and collides with anything, is deleted after one second
        if (this.transform.IsChildOf(parent) == false)
        {
            Invoke("DestroyMe", 1f);
            FindObjectOfType<AudioManager>().Play("OnCollide");
        }
        //Kill player when player is hit by bullet
        if (collision.collider.name == "FPSController")
        {
            OnHoverBorder.singlePickup = true;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);

        }
    }

    //Destroys gameObject when called
    void DestroyMe()
    {
        Destroy(gameObject);
    }
}
