using UnityEngine;
using System.Collections;

public class AnimatedProjector : MonoBehaviour
{
    public float fps = 30.0f;
    private Texture2D[] framesBlackAndWhite, framesBlackAndWhite2;
    public Texture2D[] frames;
    private int frameIndex;
    private Projector projector;


    public enum RefractionStyle
    {
        blackAndWhite, blackAndWhite2
    }

    public RefractionStyle refractionStyle;

    void Start()
    {
        projector = GetComponent<Projector>();
        framesBlackAndWhite = Resources.LoadAll<Texture2D>("caustics");
        framesBlackAndWhite2 = Resources.LoadAll<Texture2D>("caustics2");
        frames = framesBlackAndWhite2;
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
            case RefractionStyle.blackAndWhite2:
                {
                    frames = framesBlackAndWhite2;
                    break;

                }
        }
        projector.material.SetTexture("_MainTex", frames[frameIndex]);
        frameIndex = (frameIndex + 1) % frames.Length;
    }
}
