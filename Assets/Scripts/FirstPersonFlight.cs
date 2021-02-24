using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This code is meant to be on an empty gameobject with a Camera as a child object.
/// I don't understand why I can't just do this on a regular camera, it annoys me
/// to no end.
/// </summary>

public class FirstPersonFlight : MonoBehaviour
{
    Transform form;                                                                     //Empty gameobject (the object this is on)
    Transform cam;                                                                      //The child
    public float moveSpeed = 1;                                                         //Setting for convenience
    public float mouseSpeed = 1;                                                        //Setting for convenience

    private Rigidbody rb;
    public float[] force;

    float yaw = 0;                                                                      //Easier to keep track of our rotation here
    float pitch = 0;

    // Start is called before the first frame update
    void Start()
    {
        form = GetComponent<Transform>();                                               //Get the components nessecary
        cam = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        float hMove = Input.GetAxisRaw("Horizontal") * Time.deltaTime;                  //Left and right buttons -> Left and right movement
        float vMove = Input.GetAxisRaw("Vertical") * Time.deltaTime;                    //Up and Down buttons -> forward and back movement

        transform.Translate(cam.forward * vMove * moveSpeed);                           //Move in the forward direction
        transform.Translate(cam.right * hMove * moveSpeed);                             //Move in the sideways direction

        yaw += Input.GetAxisRaw("Mouse X") * mouseSpeed;                                //Rotate sideways
        pitch -= Input.GetAxisRaw("Mouse Y") * mouseSpeed;                              //Rotate up/down

        cam.eulerAngles = new Vector3(pitch, yaw, 0.0f);                                //Assign that rotation


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            Debug.Log("Jump");

            //Box goes up
            rb.AddForce(Vector3.up * force[0]);


        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            Debug.Log("left");

            //Box goes up
            rb.AddForce(Vector3.left * force[0]);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            Debug.Log("right");

            //Box goes up
            rb.AddForce(Vector3.right * force[0]);
        }

        else if (Input.GetButton("Fire1"))
        {
            transform.Translate(-cam.up * moveSpeed * Time.deltaTime);                  //Press Left CTRL (or left mouse) and move down.
        }
    }
}
