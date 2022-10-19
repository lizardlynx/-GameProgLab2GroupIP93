using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed;
    private float jumpSpeed;
    private Rigidbody rb;
    private bool grounded;
    public Transform orientation;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 20f;
        jumpSpeed = 15f;
        grounded = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = orientation.forward * zDirection + orientation.right * xDirection;

        Vector3 velocity = rb.velocity;
        velocity.x = moveDirection.x * speed;
        velocity.z = moveDirection.z * speed;
        rb.velocity = velocity;

        if (grounded && (Input.GetKeyDown(KeyCode.Space))) 
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Ground") {
            grounded = true;
        } 
    }

    private void OnCollisionExit(Collision other) 
    {
        if (other.gameObject.tag == "Ground") {
            grounded = false;
        }
    }
}
