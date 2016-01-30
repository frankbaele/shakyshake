using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	public int bpm;
	float interval;
	int note = 0;
	// Use this for initialization
	void Start () {
		startTimer();

	}
	
	void tick (){
		Events.instance.Raise(new TimerTick(note, bpm, interval));
		note = note == 15 ? 0 : note + 1;
	}
	
	void startTimer(){
		interval =  60/(float)bpm/4;
		InvokeRepeating("tick", 0, interval);
	}
	void stopTimer(){
		CancelInvoke("tick");
	}
	// Update is called once per frame
	void Update () {
	
	}

	
}
