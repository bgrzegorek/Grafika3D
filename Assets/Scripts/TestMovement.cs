using UnityEngine;
using System.Collections;

public class TestMovement : MonoBehaviour {

    public float xRotationSpeed;
    public float yRotationSpeed;
    public float zRotationSpeed;
    public float movementSpeed;
    public float rotationTime;

    public float xMax;
    public float zMax;
    public float xMin;
    public float zMin;

    bool collisionDetected = false;

    void Start()
    {
        Invoke("ChangeRotation", rotationTime);
    }

    void ChangeRotation()
    {
        if (Random.value > 0.5f)
        {
            xRotationSpeed = -xRotationSpeed;
            yRotationSpeed = -yRotationSpeed;
            zRotationSpeed = -zRotationSpeed;
        }
        Invoke("ChangeRotation", rotationTime);
    }


    void Update()
    {

        // transform.position += transform.up * movementSpeed / 10 * Time.deltaTime;
        // transform.local = new Vector3(transform.forward * movementSpeed * Time.deltaTime, transform.forward * movementSpeed * Time.deltaTime, transform.forward * movementSpeed * Time.deltaTime);
        //transform.localPosition = new Vector3(transform.localPosition.x + 0.5f, transform.localPosition.y, transform.localPosition.z + 0.5f);

    
        
        transform.Rotate(new Vector3(xRotationSpeed * Time.deltaTime, yRotationSpeed * Time.deltaTime, zRotationSpeed * Time.deltaTime));
        transform.position += transform.forward * movementSpeed * Time.deltaTime;


        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            //Debug.Log("Oho, coś się dzieje :D");
            Debug.Log(hit.collider.gameObject.name + " distance: " + hit.distance);
        }


    }

    /*
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collider name: " + collider.name);
        Debug.Log("GameObject name: " + collider.gameObject.name);
        
    }
    */
    /*
    void OnTriggerStay(Collider collider)
    {
        if (collider.name.Equals("Terrain"))
        {
            transform.Rotate(40.0f * Vector3.up * Time.deltaTime);
        } else
        {
            transform.Rotate(20.0f * Vector3.up * Time.deltaTime);
        }
    }/*
    /*
    void OnTriggerExit()
    {
        movementSpeed *= 2;
    }
    */
}
