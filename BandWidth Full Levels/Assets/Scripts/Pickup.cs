using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject hand;
    public float throwForce = 4.0f;

    //Used to grab objects (now obsolete I believe)
    public void Hold()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        this.transform.position = hand.transform.position;
        this.transform.parent = GameObject.Find("PlayerHand").transform;

    }

    //Used to throw  held objects (now obsolete)
    public void Throw()
    {
        this.transform.parent = null;
        GetComponent<Collider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponent<Rigidbody>().AddForce(0, 0, throwForce, ForceMode.Impulse);
    }
}
