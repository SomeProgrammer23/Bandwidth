using UnityEngine;

public class OnHoverBorder : MonoBehaviour
{
    public Material border;
    public Material nonBorder;
    private bool pickup;
    public GameObject hand;
    public float throwForce = 400.0f;
    public bool held;
    private Vector3 holdPos = new Vector3(0,0,0);


    void OnMouseOver()
    {
        GetComponent<Renderer>().material = border;
        pickup = true;
    }


    void OnMouseExit()
    {
        GetComponent<Renderer>().material = nonBorder;
        pickup = false;
    }

    void Update()
    {
        if(pickup == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GetComponent<Collider>().enabled = false;
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().velocity = holdPos;
                GetComponent<Rigidbody>().angularVelocity = holdPos;
                held = true;
                this.transform.position = hand.transform.position;
                this.transform.localRotation = Quaternion.Euler(holdPos);
                this.transform.parent = GameObject.Find("PlayerHand").transform;
            }
        }
        if (held == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                GetComponent<Rigidbody>().AddForce(0, 0, throwForce, ForceMode.Impulse);
                this.transform.parent = null;
                GetComponent<Collider>().enabled = true;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                
                held = false;
            }
        }
    }
}
