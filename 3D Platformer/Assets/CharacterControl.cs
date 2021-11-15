using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public float maxSpeed = 10.0f;
    public float noramalSpeed = 20.0f;
    public float sprintSpeed = 40.0f;
    float rotation = 0.0f;
    float camRotation = 0.0f;
    public float rotationSpeed = 2.0f;
    public float camRotationSpeed = 1.5f;
    GameObject cam;
    Rigidbody myRigidbody;

    bool isOnGround;
    public GameObject groundChecker;
    public LayerMask groundLayer;
    public float jumpForce = 300.0f;

    public float maxSprint = 5.0f;
    float sprintTimer;
 
    // Start is called before the first frame update
    void Start()
    {
        isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.1f, groundLayer);
        cam = GameObject.Find("Main Camera");
        sprintTimer = maxSprint;
        myRigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = transform.position + (transform.forward * Input.GetAxis("Vertical") * maxSpeed);
        //transform.position = transform.position + (transform.right * Input.GetAxis("Horizontal") * maxSpeed);

        isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.1f, groundLayer);

        Vector3 newVelocity = transform.forward * Input.GetAxis("Vertical") * maxSpeed;
        Vector3 newVelocity2 = transform.right * Input.GetAxis("Horizontal") * maxSpeed;
        Vector3 finalVelocity = newVelocity + newVelocity2;

        myRigidbody.velocity = new Vector3(finalVelocity.x, myRigidbody.velocity.y, finalVelocity.z);

        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        camRotation = camRotation + Input.GetAxis("Mouse Y") * camRotationSpeed;
        cam.transform.localRotation = Quaternion.Euler(new Vector3(-camRotation, 0.0f, 0.0f));

        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space)) 
        {
            myRigidbody.AddForce(transform.up * jumpForce);
        }

        if (Input.GetKey(KeyCode.LeftShift) && sprintTimer > 0.0f)
        {
            maxSpeed = sprintSpeed;
            sprintTimer = sprintTimer - Time.deltaTime;
        }
        else
        {
            maxSpeed = noramalSpeed;
            if (Input.GetKey(KeyCode.LeftShift) == false){
                sprintTimer = sprintTimer + Time.deltaTime;
            }          
            
        }
        sprintTimer = Mathf.Clamp(sprintTimer, 0.0f, maxSprint);
    }
}