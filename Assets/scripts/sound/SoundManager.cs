using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	public AudioClip kick;
	public AudioClip snare;
	private AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
		Events.instance.AddListener<TimerTick>(tick);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void tick(TimerTick e){
		if(e.note%4 == 0){
			audio.PlayOneShot(kick, 1F);
		}
		if(e.note%2 == 0){
			//audio.PlayOneShot(snare, 1F);
		}
	}
}
