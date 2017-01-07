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

        transform.Rotate(new Vector3(xRotationSpeed * Time.deltaTime, yRotationSpeed * Time.deltaTime, zRotationSpeed * Time.deltaTime));
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
        // transform.position += transform.up * movementSpeed / 10 * Time.deltaTime;
        // transform.local = new Vector3(transform.forward * movementSpeed * Time.deltaTime, transform.forward * movementSpeed * Time.deltaTime, transform.forward * movementSpeed * Time.deltaTime);
        //transform.localPosition = new Vector3(transform.localPosition.x + 0.5f, transform.localPosition.y, transform.localPosition.z + 0.5f);
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
        //transform.position -= transform.forward * movementSpeed * Time.deltaTime;
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
    }
    
    void OnTriggerEnter()
    {

        Debug.Log("OnTriggerEnter");
        transform.position -= transform.forward * movementSpeed * Time.deltaTime;
    }
}
