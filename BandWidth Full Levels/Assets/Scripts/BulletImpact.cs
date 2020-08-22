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
            FindObjectOfType<AudioManager>().Play("OnCollide");
        }

        if (collision.collider.name == "FPSController")
        {
            OnHoverBorder.singlePickup = true;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);

        }
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }
}
