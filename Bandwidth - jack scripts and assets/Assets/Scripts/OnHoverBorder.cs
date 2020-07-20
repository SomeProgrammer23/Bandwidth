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

    private Vector2 rotation;
    public Transform heldItem;
    public float Speed =3.0f;

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
                //this.transform.localRotation = Quaternion.Euler(holdPos);

                rotation.y += Input.GetAxis("Mouse X") * Speed * -Time.unscaledDeltaTime;
                rotation.x += -Input.GetAxis("Mouse Y") * Speed * -Time.unscaledDeltaTime;
                heldItem.localRotation = Quaternion.AngleAxis(rotation.x, Vector3.up);
                heldItem.localRotation = Quaternion.AngleAxis(rotation.y, Vector3.right);

                //heldItem.transform.LookAt(transform.forward);

                this.transform.parent = GameObject.Find("PlayerHand").transform;
            }
        }
        if (held == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                //GetComponent<Rigidbody>().AddForce(0, 0, throwForce, ForceMode.Impulse);
                GetComponent<Rigidbody>().AddForce(transform.forward * throwForce, ForceMode.Impulse);
                this.transform.parent = null;
                GetComponent<Collider>().enabled = true;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

                held = false;
            }
        }
    }
}
