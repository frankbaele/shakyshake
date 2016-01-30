using UnityEngine;
using System.Collections;

public class beatVisualisationScript : MonoBehaviour {

    public GameObject beatVisualizerPrefab; // private or public?

    private bool isVisible;
    private Vector3 position;
    private GameObject visualisationObject;


	// Use this for initialization
	void Start () {
        Events.instance.AddListener<TimerTick>(tick);
        position = GetComponent<Transform>().position;
        visualisationObject = (GameObject)Instantiate(beatVisualizerPrefab, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update () {

        //this will hide too fast. it will only show 1 frame
        if (isVisible)
        {
            hide(visualisationObject);

        }
	
	}

    void tick(TimerTick e)
    {
        show(visualisationObject);
    }

    private void show(GameObject gameObject)
    {
        gameObject.GetComponent<Renderer>().enabled = true;
        isVisible = true;
    }

    private void hide(GameObject gameObject)
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        isVisible = false;
    }
}
