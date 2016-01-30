using UnityEngine;
using System.Collections;

public class beatAnimation : MonoBehaviour {

    public Sprite[] frames;

    private int frameIndex = 0;
    private SpriteRenderer r;
    private Animator anim;
    private bool continueAnimation = false;
    int count = 0;

    // Use this for initialization
    void Start () {
        r = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Events.instance.AddListener<TimerTick>(tick);
    }

    // Update is called once per frame
    void Update() {

    }

    void tick(TimerTick e)
    {   
        anim.Play("Shaman", 0, 5f / 7f);
    }
}
