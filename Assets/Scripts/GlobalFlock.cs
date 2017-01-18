using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlock : MonoBehaviour {

    // 500 x 500 <- center of the terrain
    public static Vector3 vectorZero = new Vector3(500.0f, 100.0f, 500.0f);
    public static int CENTER_X = 500;
    public static int CENTER_Z = 500;
    public static int MOVEMENT_RANGE = 300;
    public GameObject fishPrefarb;
    static int numberOfFish = 25;
    public static GameObject[] allFish = new GameObject[numberOfFish];

    //public static Vector3 goalPosition = Vector3.zero;
    public static Vector3 goalPosition = new Vector3(CENTER_X, 100.0f, CENTER_Z);

    // Use this for initialization
    void Start () {
		for(int i = 0; i < numberOfFish; i++)
        {
            Vector3 pos = new Vector3(Random.Range(CENTER_X - MOVEMENT_RANGE, CENTER_X + MOVEMENT_RANGE),
                                      Random.Range(25, 150),
                                      Random.Range(CENTER_Z - MOVEMENT_RANGE, CENTER_Z + MOVEMENT_RANGE));
            allFish[i] = (GameObject)Instantiate(fishPrefarb, pos, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(Random.Range(0, 10000) < 50)
        {
            goalPosition = new Vector3(Random.Range(0.0f, CENTER_X + MOVEMENT_RANGE),
                                       Random.Range(25, 150),
                                       Random.Range(0.0f, 2 * CENTER_Z + MOVEMENT_RANGE));

            Debug.Log("Goal Position: " + goalPosition.ToString());
        }
	}
}
