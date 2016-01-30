using UnityEngine;
using System.Collections;

public class beatAnimation : MonoBehaviour {
    public Texture2D[] frames;

    private int frameIndex;
    private Renderer r;

    // Use this for initialization
    void Start () {
        r = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update () {
	
	}

    void tick(TimerTick e)
    {
        if (e.note % 2 == 0)
        {
            //go to next step in animation
            r.material.mainTexture = frames[frameIndex];
        }

    }
}
