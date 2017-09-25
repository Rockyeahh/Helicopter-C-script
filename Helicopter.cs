using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

    private bool called = false;
    private Rigidbody rigidBody;
    private GameObject landingArea;
    public float speed;
   // public float speedy;


    void Start () {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update() // It keeps being called, may need to be a fixed update.
    {
        //OnDispatchHelicopter();
        if (called == true)
        {
            float MetersPerSecond = speed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(transform.position, landingArea.transform.position, MetersPerSecond); // Error not set to an instance of an object.  
            Debug.Log("Helicopter Departing");
        }
    }

    void OnDispatchHelicopter()
    {
            landingArea = GameObject.FindGameObjectWithTag("LandingArea"); // Finding the landing Area with the tag.
            rigidBody.velocity = new Vector3(0, 0, 50f); // This isn't happening.
            
            Debug.Log("Helicopter called");

        // if on collision or something. Set velocity from 50f to 0.
        // Move to position on the ground or slightly above it.
    }

    void OnTriggerEnter (Collider coll)
    {
        rigidBody.velocity = new Vector3(0, 0, 0);
        called = true;
    }

}
