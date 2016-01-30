﻿using UnityEngine;
using System.Collections;

public class beatVisualisationScript : MonoBehaviour {

    public GameObject beatVisualizerPrefab; // private or public?

    private bool isVisible;
    private Vector3 position;
	private Renderer r;

	// Use this for initialization
	void Start () {
		r = GetComponent<Renderer>();
        Events.instance.AddListener<TimerTick>(tick);
        position = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update () {

	
	}

    void tick(TimerTick e)
    {
	    if(e.note%2 == 0){
		    if (isVisible)
		    {
		    	Debug.Log("hide");
			    hide();
			    
		    } else {
			    Debug.Log("show");
			    show();
		    }
	    }

    }

    private void show()
    {
	    r.enabled = true;
        isVisible = true;
    }

    private void hide()
    {
	    r.enabled = false;
        isVisible = false;
    }
}
