
using System.Collections;
using UnityEngine;

public class Flock : MonoBehaviour {
    

    public float speed = 1.0f;
    public float rotationSpeed = 0.5f;
    Vector3 averageHeading;
    Vector3 averagePosition;
    public float neighbourDistane = 150.0f;

    bool turning = false;

    // Use this for initialization
    Animation anim;

    void Start () {
        speed = speed * Random.Range(0.8f, 1.0f);
        anim = GetComponent<Animation>();
        float startPoint = Random.Range(0f, 2.5f);

        //Debug.Log("GO name: " + name + ";  Animation name: " + anim.name);
        string animName = "Armature|ArmatureAction";

         anim[animName].time = startPoint;
         anim[animName].speed = 1.0f;
        anim.Play(animName);
        float len = anim[animName].length;
    }

    // Update is called once per frame
    void Update () {
        
        if(Vector3.Distance(transform.position, GlobalFlock.vectorZero) >= GlobalFlock.MOVEMENT_RANGE)
        {
            turning = true;
        }
        else
        {
            turning = false;
        }
        if(turning)            
        {
            Vector3 direction = GlobalFlock.vectorZero - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                  Quaternion.LookRotation(direction),
                                                  rotationSpeed * Time.deltaTime);

            //speed = speed * Random.Range(0.8f, 1);
           // speed = 20.0f;
        }
        else
        {
            if (Random.Range(0, 5) < 1)
                applyRules();
        }
        transform.Translate(0, 0, Time.deltaTime * speed);
	}

    private void applyRules()
    {
        GameObject[] gos;
        gos = GlobalFlock.allFish;

        Vector3 vcentre = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 10.0f;

        Vector3 goalPosition = GlobalFlock.goalPosition;

        float dist;

        int groupSize = 0;
        foreach (GameObject go in gos)
        {
            if(go != this.gameObject)
            {
                dist = Vector3.Distance(go.transform.position, this.transform.position);
                if(dist <= neighbourDistane)
                {
                    vcentre += go.transform.position;
                    groupSize++;

                    if (dist < 50.0f)
                    {
                        vavoid += (this.transform.position - go.transform.position);
                    }

                    Flock anotherFlock = go.GetComponent<Flock>();
                    gSpeed += anotherFlock.speed;
                    //Debug.Log("gropu size: " + groupSize + "; group speed = " + gSpeed);
                }
            }
        }

        if(groupSize > 0)
        {
            vcentre = vcentre / groupSize + (goalPosition - this.transform.position);
            //speed = gSpeed / groupSize;
            Debug.Log("groupSize = " + groupSize + "; speed = " + speed);

            Vector3 direction = (vcentre + vavoid) - transform.position;
            if (direction != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation,
                                                      Quaternion.LookRotation(direction), 
                                                      rotationSpeed * Time.deltaTime);
        }
    }
}
