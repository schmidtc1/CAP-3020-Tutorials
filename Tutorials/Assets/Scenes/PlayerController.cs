using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public float jumpStrength = 1.0f;

    public float rotationSpeed = 1.0f;
    public float verticalAngleLimit = 85.0f;

    private Vector3 currentRotation;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //Grab the rigidbody we want to manipulate for movement
        rb = GetComponent<Rigidbody>();
        if (rb == null) rb = GetComponentInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //=======Lateral movement==========
        //MovePlayerBad();
        MovePlayerGood();


        //======Jumping========
        Jump();

        //=======Rotation=========
        Rotate();
    }


    void MovePlayerGood()
    {
        //A "Good" way for lateral player movement.
        //Idea:
        //1) get input from WASD keys to determine direction of movement
        //2) normalize based on movementSpeed
        //3) apply to rigidbody

        //start with no lateral movement AND save y velocity
        Vector3 direction = new Vector3(0,0,0);
        float y = rb.velocity.y;

        //for each movement key, update direction of movement
        if (Input.GetKey(KeyCode.W))
        {
            direction += gameObject.transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction -= gameObject.transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction -= gameObject.transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += gameObject.transform.right;
        }

        //normalize, then scale based on speed
        Vector3 velocity = direction.normalized * movementSpeed;
        //return y velocity
        velocity.y = y;
        //apply the velocity to the player
        rb.velocity = velocity;
    }

    //
    void MovePlayerBad()
    {
        //There are many "bad" ways to do movement, but this is one way.
        //This differs from MovePlayerGood in one way: the direction vector is not normalized.
        //Consider a case were the player presses both W and S at one time.
        //A vector of total length sqrt(2) is used to calculate movement so the player is actually quicker when moving diagonally.

        //start with no movement AND save y velocity
        Vector3 direction = new Vector3(0, 0, 0);
        float y = rb.velocity.y;

        //for each movement key, update direction of movement
        if (Input.GetKey(KeyCode.W))
        {
            direction += gameObject.transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction -= gameObject.transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction -= gameObject.transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += gameObject.transform.right;
        }

        //scale based on speed
        Vector3 velocity = direction * movementSpeed;
        //return y velocity
        velocity.y = y;
        //apply the velocity to the player
        rb.velocity = velocity;
    }


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(gameObject.transform.up*jumpStrength, ForceMode.Impulse);
        }
    }

    void Rotate()
    {
        currentRotation.x += Input.GetAxis("Mouse X") * rotationSpeed;
        currentRotation.y -= Input.GetAxis("Mouse Y") * rotationSpeed;
        currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
        currentRotation.y = Mathf.Clamp(currentRotation.y, -verticalAngleLimit, verticalAngleLimit);
        gameObject.transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
    }
}

