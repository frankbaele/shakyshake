using UnityEngine;
using System.Collections;

public class beatAnimation : MonoBehaviour {

    public Sprite[] frames;

	private Animator anim;
	private bool playing;


    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	    Events.instance.AddListener<TimerTick>(tick);

    }

    // Update is called once per frame
    void Update() {

    }

    void tick(TimerTick e)
	{   
		if(!playing){
			anim.Play("Shaman");
			anim.speed = 1/e.interval*2/8;
			playing = true;
		}
    }
}
