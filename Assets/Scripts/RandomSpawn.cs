using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject gameObject;
    static int numberOfObjects = 2000;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 pos = new Vector3(Random.Range(GlobalFlock.CENTER_X - GlobalFlock.MOVEMENT_RANGE, GlobalFlock.CENTER_X + GlobalFlock.MOVEMENT_RANGE),
                                      Random.Range(0, 5),
                                      Random.Range(GlobalFlock.CENTER_Z - GlobalFlock.MOVEMENT_RANGE, GlobalFlock.CENTER_Z + GlobalFlock.MOVEMENT_RANGE));

            Instantiate(gameObject, pos, Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
