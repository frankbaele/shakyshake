using UnityEngine;
using System.Collections;

public class beatToggle : MonoBehaviour {

	public Sprite sprite_passive;
	public Sprite sprite_active;

	
	// Use this for initialization
	void Start () {
	Events.instance.AddListener<TimerTick>(tick);
		GetComponent<SpriteRenderer>().sprite = sprite_passive;
	}
	
    // Update is called once per frame
	void Update () {
		
		
	}
	
	void tick(TimerTick e)
	{
		GetComponent<SpriteRenderer>().sprite = sprite_passive;
		if(e.note%4 == 0){
			GetComponent<SpriteRenderer>().sprite = sprite_active;
		}
	}
}
