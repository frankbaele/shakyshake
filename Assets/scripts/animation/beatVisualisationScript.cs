using UnityEngine;
using System.Collections;

public class beatVisualisationScript : MonoBehaviour {

	public Sprite sprite_passive;
	public Sprite sprite_color_1;
	public Sprite sprite_color_2;
    private bool isVisible;
    private Vector2 position;
	private Renderer r;

	// Use this for initialization
	void Start () {
		r = GetComponent<Renderer>();
        Events.instance.AddListener<TimerTick>(tick);
		position = GetComponent<Transform>().position;
		GetComponent<SpriteRenderer>().sprite = sprite_passive;
    }

    // Update is called once per frame
    void Update () {

	
	}

    void tick(TimerTick e)
    {
	    if(e.note%2 == 0){

	    }

    }

}
