using UnityEngine;
using System.Collections;

public class beatAnimation : MonoBehaviour {

    public Sprite[] frames;

    private int frameIndex = 0;
    private SpriteRenderer r;
    private bool continueAnimation = false;
    int count = 0;
   // private GameObject shamanAnimation;
    //private Animator anim;

    // Use this for initialization
    void Start () {
        r = GetComponent<SpriteRenderer>();
       // anim = GetComponent<Animator>();
        //anim.StartPlayback();
        Events.instance.AddListener<TimerTick>(tick);
        //shamanAnimation = GameObject.Find("ShamanAnimation");
    }

    // Update is called once per frame
    void Update() {

        //r.sprite = frames[frameIndex];

    }

    void tick(TimerTick e)
    {   
        if(count == 4)
        {

        }
            //go to next step in animation
            //frameIndex = frameIndex % frames.Length;
            //Debug.Log("index" + frameIndex);
            //r.sprite = frames[frameIndex];

            //frameIndex++;
        GetComponent<Animator>().Play("Shaman", 0, 5f / 7f);
    }
}
