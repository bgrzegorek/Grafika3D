using UnityEngine;
using System.Collections;

public class MouseCameraControl : MonoBehaviour
{

    //Define variable
    public int underwaterLevel = 40;
    public float yPosition;

    //The scene's default fog settings
    public bool defaultFog;
    public Color underwaterFogColor;
    public float underwaterFogDensity;// = RenderSettings.fogDensity;

    public float lookSpeed = 5.0f;
    public float moveSpeed = 3.0f;
    public float rotationX = 0.0f;
    public float rotationY = 0.0f;

    private Material defaultSkybox = RenderSettings.skybox;
    private Material noSkybox;

    private GameObject water, refraction;


    void Start()
    {
        transform.position = new Vector3(1000.0f, 100.0f, 1000.0f);
       // RenderSettings.skybox = noSkybox;

        water = GameObject.Find("Water");
        refraction = GameObject.Find("Refraction");

        // defaultFog = RenderSettings.fog;        // zrobić defaulotow w zależności od położenia kamery
        underwaterFogDensity = 0.0015f;
        underwaterFogColor = new Color(0.13f, 0.56f, 0.56f, 0f);
        underwaterFogColor = new Color32(60, 100, 120, 255);
        RenderSettings.fogMode = FogMode.ExponentialSquared;
        RenderSettings.fogColor = underwaterFogColor;
        RenderSettings.fogDensity = underwaterFogDensity;
        // RenderSettings.fog = defaultFog;

        RenderSettings.fog = true;
        refraction.SetActive(true);
    }

    void Update()
    {
        RenderSettings.fogColor = underwaterFogColor;
        RenderSettings.fogDensity = underwaterFogDensity;


        yPosition = transform.position.y;
        rotationX += Input.GetAxis("Mouse X") * lookSpeed;
        rotationY += Input.GetAxis("Mouse Y") * lookSpeed;
        rotationY = Mathf.Clamp(rotationY, -90, 90);
      
        transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

        transform.position += transform.forward * moveSpeed * Input.GetAxis("Vertical");
        transform.position += transform.right * moveSpeed * Input.GetAxis("Horizontal");
/*
        if (transform.position.y < underwaterLevel)
        {
            //water.SetActive(false);
            refraction.SetActive(true);
            RenderSettings.fog = true;
            //RenderSettings.skybox = noSkybox;
        }
        else
        {
           // water.SetActive(true);
            refraction.SetActive(false);
            RenderSettings.fog = false;
            //RenderSettings.skybox = defaultSkybox;
        }*/
    }

}