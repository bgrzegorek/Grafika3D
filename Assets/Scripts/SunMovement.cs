using UnityEngine;
using System.Collections;

public class SunMovement : MonoBehaviour {

    public float dayLength;
    public float rotationSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        rotationSpeed = Time.deltaTime / dayLength;

        transform.Rotate(0, rotationSpeed, 0);
    }
}
