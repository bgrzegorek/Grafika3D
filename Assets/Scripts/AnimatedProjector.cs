using UnityEngine;
using System.Collections;

public class AnimatedProjector : MonoBehaviour
{
    public float fps = 30.0f;
    private Texture2D[] framesBlackAndWhite, framesLightBlue, framesBlue, framesDarkBLue;
    public Texture2D[] frames;
    private int frameIndex;
    private Projector projector;


    public enum RefractionStyle
    {
        blackAndWhite, lightBlue, blue, darkBlue
    }

    public RefractionStyle refractionStyle = RefractionStyle.lightBlue;
    private string path;

    void Start()
    {
        projector = GetComponent<Projector>();
        framesBlackAndWhite = Resources.LoadAll<Texture2D>("caustics");
        framesLightBlue = Resources.LoadAll<Texture2D>("caustics_light_blue");
        framesBlue = Resources.LoadAll<Texture2D>("caustics_blue");
        framesDarkBLue = Resources.LoadAll<Texture2D>("caustics_dark_blue");
        frames = framesLightBlue;
        frameIndex = 0;
        InvokeRepeating("NextFrame", 0, 1 / fps);
    }

    void NextFrame()
    {
        switch(refractionStyle)
        {
            case RefractionStyle.blackAndWhite: {
                    frames = framesBlackAndWhite;
                    break;
                }
            case RefractionStyle.lightBlue:
                {
                    frames = framesLightBlue; ;
                    break;

                }
            case RefractionStyle.blue:
                {
                    frames = framesBlue;
                    break;

                }
            case RefractionStyle.darkBlue:
                {
                    frames = framesDarkBLue;
                    break;

                }
        }
        projector.material.SetTexture("_MainTex", frames[frameIndex]);
        frameIndex = (frameIndex + 1) % frames.Length;
    }
}
