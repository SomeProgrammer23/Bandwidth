using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class EnemyTemp : MonoBehaviour
{
    public GameObject gun;
    public Transform barrel;
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
            this.GetComponent<Rigidbody>().useGravity = false;
            this.GetComponent<Rigidbody>().velocity = holdPos;
            this.GetComponent<Rigidbody>().angularVelocity = holdPos;
            this.GetComponent<Rigidbody>().isKinematic = true;
        }
        else
        {
            gun.GetComponent<Rigidbody>().useGravity = true;
            gun.GetComponent<Rigidbody>().isKinematic = false;
            gun.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.GetComponent<Rigidbody>().useGravity = true;
            this.GetComponent<Rigidbody>().isKinematic = false;
            gun.transform.parent = null;
            this.transform.parent = null;
            Destroy(this.GetComponent<TempAIController>());
            Destroy(this.GetComponent<NavMeshAgent>());
            Destroy(this);
            
        }


        
    }

    private void OnTriggerStay(Collider other)
    {
        RaycastHit detectHit;
        if (Physics.Raycast(barrel.position, barrel.forward, out detectHit))
        {
            if (detectHit.collider == GameObject.Find("HitBox").GetComponent<Collider>())
            {
                Debug.Log("hit");
                if (other.name == "FPSController" && alive == true)
                {
                    gun.GetComponent<Animator>().SetTrigger("Fire");
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Projectile")
        {
            if(collision.relativeVelocity.magnitude > 2)
            {
                alive = false;
            }
        }
    }
}
