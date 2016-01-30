using UnityEngine;
using System.Collections;

public class beatAnimation : MonoBehaviour {

    public Sprite[] frames;

    private int frameIndex = 0;
    private SpriteRenderer r;
    //private Animator anim;

    // Use this for initialization
    void Start () {
        r = GetComponent<SpriteRenderer>();
       // anim = GetComponent<Animator>();
        //anim.StartPlayback();
        Events.instance.AddListener<TimerTick>(tick);
    }

    // Update is called once per frame
    void Update() {
     
      
        //r.material.mainTexture = frames[frameIndex]

    }

    void tick(TimerTick e)
    {
        if(e.note % 4 == 0)
        {
            //go to next step in animation
            frameIndex = frameIndex % frames.Length;
            Debug.Log("index" + frameIndex);
            r.sprite = frames[frameIndex];

            frameIndex++;
        }
        
    
    }
}
