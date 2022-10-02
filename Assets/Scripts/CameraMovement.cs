using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform orientation;
    public Transform player;
    public Transform playerObject;
    private Rigidbody playerRb;

    private float rotationSpeed = 7;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = player.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // get and set the direction of need vector of player to orient to
        Vector3 lookDirection = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = lookDirection.normalized;

        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        // get direction to move torwards, move player smoothly torwards it  
        Vector3 goDirection = orientation.forward * zDirection + orientation.right * xDirection;
        if (goDirection != Vector3.zero) 
        {
            playerObject.forward = Vector3.Slerp(playerObject.forward, goDirection.normalized, Time.deltaTime * rotationSpeed);
        }
    }
}
