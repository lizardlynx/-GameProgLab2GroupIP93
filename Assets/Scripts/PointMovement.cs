using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMovement : MonoBehaviour
{
    private bool up = false;
    private float speed = 0.5f;
    private int times = 0;
    private Rigidbody rb;
    public GameObject text;
    private bool collided = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        times += 1;
        // Debug.Log()
        if (up && times >= 10) 
        {
            var velocity = rb.velocity;
            velocity.y = -1 * speed;
            rb.velocity = velocity;
            times = 0;
            up = false;
        } 
        else if (!up && times >= 10)
        {
            var velocity = rb.velocity;
            velocity.y = 1 * speed;
            rb.velocity = velocity;
            times = 0;
            up = true;
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (!collided && other.gameObject.tag == "Player") 
        {
            collided = true;
            Scored textScript = text.GetComponent<Scored>();
            textScript.Toggle();
            Destroy(gameObject);

        } 
    }
}
