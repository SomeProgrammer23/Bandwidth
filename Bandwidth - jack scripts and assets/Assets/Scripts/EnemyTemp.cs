using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTemp : MonoBehaviour
{
    public GameObject gun;
    private bool alive = true;
    private Transform target;
    //private HandGun HandGun;
    private Vector3 holdPos = new Vector3(0, 0, 0);


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(alive == true)
        {
            target = GameObject.Find("FPSController").transform;
            gun.GetComponent<Rigidbody>().useGravity = false;
            gun.GetComponent<Rigidbody>().isKinematic = true;
            gun.transform.LookAt(target);
            gun.GetComponent<Rigidbody>().velocity = holdPos;
            gun.GetComponent<Rigidbody>().angularVelocity = holdPos;
        }
        else
        {
            gun.GetComponent<Rigidbody>().useGravity = true;
            gun.GetComponent<Rigidbody>().isKinematic = false;
            gun.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            gun.transform.parent = null;
            Destroy(this);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "FPSController" && alive == true)
        {
            gun.GetComponent<Animator>().SetTrigger("Fire");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == gun)
        {
            Physics.IgnoreCollision(gun.GetComponent<Collider>(), GetComponent<Collider>());
            return;
        }
        else if (collision.collider.name == "FPSController")
        {
            Physics.IgnoreCollision(GameObject.Find("FPSController").GetComponent<Collider>(), GetComponent<Collider>());
            return;
        }
        else
        {
            alive = false;
        }
    }
}
