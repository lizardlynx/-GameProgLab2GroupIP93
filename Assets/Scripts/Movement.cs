using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 20f;
    private float jumpSpeed = 15f;
    private Rigidbody rb;
    private bool grounded = false;
    public Transform orientation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = orientation.forward * zDirection + orientation.right * xDirection;
        var velocity = rb.velocity;
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
