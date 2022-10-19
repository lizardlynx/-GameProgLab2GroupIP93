using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMovement : MonoBehaviour
{
    public GameObject text;
    private bool collided = false;

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
