using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ChangeCamera : MonoBehaviour {
	// Define Cams
	public Camera camera1;
	public Camera camera2;

    void Start() {
        camera1.enabled = true;
        camera2.enabled = false;
    }

    void Update() {
        // Check for input and swap accordingly
        if (Input.GetButtonDown("ChangeCamera"))
        {
            camera1.enabled = !camera1.enabled;
            camera2.enabled = !camera2.enabled;
        }
    }
}