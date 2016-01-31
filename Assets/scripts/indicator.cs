using UnityEngine;
using System.Collections;

public class indicator : MonoBehaviour {
	public string playerid;
	// Use this for initialization
	void Start () {
		Events.instance.AddListener<indicatorEvent>(indication);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void indication(indicatorEvent e){
		if (e.Player == playerid){
			//Debug.Log("event");
		}
	}
}
