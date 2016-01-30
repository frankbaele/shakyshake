using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
private AudioSource audio;
	public AudioClip clap;
	public AudioClip closed;
	public AudioClip crash;
	public AudioClip high;
	public AudioClip kick;
	public AudioClip mid;
	public AudioClip open;
	public AudioClip perc1;
	public AudioClip perc2;
	public AudioClip rim;
	public AudioClip shake;
	public AudioClip snare;
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
		if(e.note == 4){
			audio.PlayOneShot(snare, 1F);
		}
		if(e.note == 3){
			audio.PlayOneShot(perc1, 1F);
		}
		if(e.note == 2 || e.note == 2){
			audio.PlayOneShot(rim, 1F);
		}
	}
}
