using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class KingMovement : MonoBehaviour {

    public GameObject player;

    private Animator anim;
    private bool correctInput;
    private Transform pivot;

    private beatTurning beatTurningScript;
    private int randomDirection;

    //private int dX;
    //private int dY;

    //Player progression
    private int level = OUTER_CIRCLE;
    private static int OUTER_CIRCLE = 1;
    private static int MIDDLE_CIRCLE = 2;
    private static int INNER_CIRCLE = 3;
    private int points; 

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        Events.instance.AddListener<TimerTick>(tick);
        pivot = transform.parent.transform;
        beatTurningScript = transform.parent.GetComponentInParent<beatTurning>();
        points = player.GetComponent<Player>().points;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void tick(TimerTick e)
    {
        Debug.Log("points: " + points);
        //if (Input.GetKey(KeyCode.Space) && e.note % 2 == 0) // for testing
        if (correctInput && e.note%2 == 0)
        {
            randomDirection = beatTurningScript.randomDirection;
            Debug.Log("King movement: randomDirection: " + randomDirection + ", euler z: " + transform.rotation.eulerAngles.z);
            transform.rotation = transform.rotation ;
            HOTween.To(transform.parent, e.interval * 2, new TweenParms()
                .Prop("localRotation", new Vector3(0, 0, gameObject.transform.rotation.eulerAngles.z + (22.5f * 0)))
               // .Prop("position", new Vector3(transform.position.x + dX , transform.position.y + dY, transform.position.z))
                .Ease(EaseType.EaseInBack));
        }
    }

}
