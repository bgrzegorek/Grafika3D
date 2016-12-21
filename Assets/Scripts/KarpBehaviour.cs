using UnityEngine;
using System.Collections;

public class KarpBehaviour : MonoBehaviour {
	private bool gravityReversed = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (gravityReversed)
        {
            //GetComponent<Rigidbody>().AddForce(Vector3.up, Physics.gravity.magnitude);
        }
	}
}
