using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	public float bpm;
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
		float wait = 60/bpm;
		while(playing){
			Events.instance.Raise(new TimerTick());
			yield return new WaitForSeconds(wait);
		}
	}
	
}
