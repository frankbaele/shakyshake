using UnityEngine;
using System.Collections;

public class treeAnimation : MonoBehaviour {

	private SpriteRenderer r;
	private Animator anim;
	private bool playing;

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
		if(!playing){
			anim.Play("tree");
			anim.speed = 1/e.interval*2/8;
			playing = true;
		}
	}
}
