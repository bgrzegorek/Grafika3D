using UnityEngine;
using System.Collections;

public class TransformForwardBehaviour : MonoBehaviour {
    public float velocidadMax;

    public float xMax;
    public float zMax;
    public float xMin;
    public float zMin;

    private float x;
    private float z;
    private float tiempo;
    private float angulo;

    // Use this for initialization
    void Start()
    {


        x = Random.Range(-velocidadMax, velocidadMax);
        z = Random.Range(-velocidadMax, velocidadMax);
        angulo = Mathf.Atan2(x, z) * (180 / 3.141592f);// + 90;
        transform.localRotation = Quaternion.Euler(0, angulo, 0);
    }

    // Update is called once per frame
    void Update()
    {

        tiempo += Time.deltaTime;

        if (transform.localPosition.x > xMax)
        {
            x = Random.Range(-velocidadMax, 0.0f);
            tiempo = 0.0f;
        }
        if (transform.localPosition.x < xMin)
        {
            x = Random.Range(0.0f, velocidadMax);
            tiempo = 0.0f;
        }
        if (transform.localPosition.z > zMax)
        {
            z = Random.Range(-velocidadMax, 0.0f);
            tiempo = 0.0f;
        }
        if (transform.localPosition.z < zMin)
        {
            z = Random.Range(0.0f, velocidadMax);
            tiempo = 0.0f;
        }
       
        if (tiempo > 1.0f)
        {
            x = Random.Range(-velocidadMax, velocidadMax);
            z = Random.Range(-velocidadMax, velocidadMax);
            tiempo = 0.0f;
        }

        angulo = Mathf.Atan2(x/10.0f, z/10.0f) * (180 / 3.141592f);
        transform.localRotation = Quaternion.Euler(0, angulo, 0);

        transform.localPosition = new Vector3(transform.localPosition.x + x, transform.localPosition.y, transform.localPosition.z + z);
        
    }
}
