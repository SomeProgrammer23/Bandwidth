using UnityEngine;

public class InstigatedPickups : MonoBehaviour
{
    public Material border;
    public Material nonBorder;
    private bool pickup;
    //public GameObject hand;
    public float throwForce = 400.0f;
    public bool held;
    private Vector3 holdPos = new Vector3(0,0,0);
    //public Transform camPos;
    private Transform camPos;
    private Transform looker;
    public float range = 3f;
    private Transform objectPoint;
    static public bool singlePickup = true;

    private OnHoverBorder OnHoverBorder;
           
    private void Start()
    {
        camPos = GameObject.Find("FirstPersonCharacter").transform;
        looker = GameObject.Find("Looker").transform;
        objectPoint = this.transform;
    }

    void Update()
    {
        //Shows that object can be picked up when within certain distance
        RaycastHit detect;
        if (Physics.Raycast(camPos.transform.position, camPos.transform.forward, out detect, range))
        {
            if (detect.collider == gameObject.GetComponent<Collider>())
            {
                GetComponent<Renderer>().material = border;
                pickup = true;
            }
            else if (detect.collider == gameObject.GetComponent<Collider>() == false)
            {
                GetComponent<Renderer>().material = nonBorder;
                pickup = false;
            }

        }
        else
        {
            GetComponent<Renderer>().material = nonBorder;
            pickup = false;
        }

        //Picks up object on mouse input based on whether player is already holding something
        if (pickup == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && singlePickup == true)
            {
                GetComponent<Collider>().enabled = false;
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().velocity = holdPos;
                GetComponent<Rigidbody>().angularVelocity = holdPos;
                held = true;
                this.transform.position = GameObject.Find("PlayerHand").transform.position;
                this.transform.parent = GameObject.Find("PlayerHand").transform;

                Invoke("PickupCheck", 0.1f);
                OnHoverBorder.singlePickup = false;
            }
        }

        //Makes held item point at a point dictated by a raycast
        RaycastHit hit;
        if (Physics.Raycast(camPos.transform.position, camPos.transform.forward, out hit/*, range*/))
        {
            looker.transform.position = hit.point;
            if (held == true)
            {
                objectPoint.transform.LookAt(looker);
                this.transform.LookAt(looker);
            }
        }

        if (held == true)
        {
            //Throws Held Object
            if (Input.GetKeyDown(KeyCode.Mouse1) && singlePickup == false)
            {
                GetComponent<Rigidbody>().AddForce(objectPoint.forward * throwForce, ForceMode.Impulse);
                this.transform.parent = null;
                GetComponent<Collider>().enabled = true;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

                held = false;
                Invoke("PickupCheckAgain", 0.1f);
                OnHoverBorder.singlePickup = true;
            }
        }
    }

    void PickupCheck()
    {
        singlePickup = false;
    }
    void PickupCheckAgain()
    {
        singlePickup = true;
    }
}
