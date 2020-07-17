using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerTest : MonoBehaviour
{
    //GOTTA GET THAT BURGER

    public GameObject fpsCam;
    public GameObject body;
    public float lookSpeed = 3.0f;
    public float moveSpeed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 movement = Vector3.zero;
    private Vector2 rotation = Vector2.zero;
    public TimeManager timeManager;

    private CollisionFlags CollisionHit;
    private CharacterController fpsController;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        fpsController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Camera look 
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        rotation.x = Mathf.Clamp(rotation.x, -20f, 20f);
        body.transform.eulerAngles = new Vector2(0, rotation.y * lookSpeed);
        fpsCam.transform.localRotation = Quaternion.Euler(rotation.x * lookSpeed, 0, 0);

        
        //Time Fiddler
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A))
        {
            timeManager.SlowTime();
            //moveSpeed = 120.0f;
        }
        else
        {
            timeManager.ReturnTime();
            //moveSpeed = 6.0f;
        }
    }

    private void FixedUpdate()
    {
        //Movement
        
        if (fpsController.isGrounded)
        {
            movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"))/*.normalized*/;
            movement = transform.TransformDirection(movement);
            //movement *= moveSpeed;
            if (Input.GetButtonDown("Jump"))
            {
                movement.y = jumpSpeed;
            }

        }
        movement.Normalize();
        movement.y -= gravity * Time.deltaTime;
        fpsController.Move(movement * Time.unscaledDeltaTime * moveSpeed);

        CollisionHit = fpsController.Move(movement * Time.fixedUnscaledDeltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        //dont move the rigidbody if the character is on top of it
        if (CollisionHit == CollisionFlags.Below)
        {
            return;
        }

        if (body == null || body.isKinematic)
        {
            return;
        }
        body.AddForceAtPosition(fpsController.velocity * 0.1f, hit.point, ForceMode.Impulse);
    }
}
