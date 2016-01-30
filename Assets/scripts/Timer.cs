using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	public int bpm;
	bool playing = false;
	// Use this for initialization
	void Start () {
		playing = true;
		StartCoroutine("timer");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private IEnumerator timer(){
		float interval = 60/(float)bpm/4;
		int note = 0;
		while(playing){
			Events.instance.Raise(new TimerTick(note, bpm, interval));
			note = note == 15 ? 0 : note + 1;
			yield return new WaitForSeconds(interval);
		}
	}
	
}
