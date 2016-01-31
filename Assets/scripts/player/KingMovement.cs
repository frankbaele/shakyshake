using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class KingMovement : MonoBehaviour {

    public int player;
    private Player playerScript;

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
    private int previousPoints;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        Events.instance.AddListener<TimerTick>(tick);
        pivot = transform.parent.transform;
        beatTurningScript = transform.parent.GetComponentInParent<beatTurning>();
        playerScript = GameObject.Find("Player" + player).GetComponent<Player>();

        tweenRotation(0);
    }

    // Update is called once per frame
    void Update () {
	
	}

    void tick(TimerTick e)
    {
        previousPoints = points;
        points = playerScript.points;
        Debug.Log("points: " + points);
        correctInput = points > previousPoints;

       // if (Input.GetKey(KeyCode.Space) && e.note % 2 == 0) // for testing
        if (correctInput && e.note%2 == 0)
        {
            randomDirection = beatTurningScript.randomDirection;
            Debug.Log("King movement: randomDirection: " + randomDirection + ", euler z: " + transform.rotation.eulerAngles.z);

            if (level == OUTER_CIRCLE && points == 16)
            {
                level = MIDDLE_CIRCLE;
                //MOVE TO MIDDLE CIRCLE
                Vector3 target = transform.localPosition - new Vector3(-2 , 0, 0);

                HOTween.To(transform, e.interval * 2, new TweenParms()
                .Prop("localPosition", target)
                .Ease(EaseType.EaseInBack));
            }
            else if (level == MIDDLE_CIRCLE && points == 32)
            {
                level = INNER_CIRCLE;
                //MOVE TO INNER CIRCLE

                Vector3 target = transform.localPosition - new Vector3(-2, 0, 0);

                HOTween.To(transform, e.interval * 2, new TweenParms()
                .Prop("localPosition", target)
                .Ease(EaseType.EaseInBack));
            }
                tweenRotation(e.interval);

        }
    }

    private void tweenRotation(float interval)
    {
        //HOTween.Complete(transform.parent);
        HOTween.To(transform.parent, interval * 2, new TweenParms()
            .Prop("localRotation", new Vector3(0, 0, (Mathf.Round((transform.localRotation.eulerAngles.z - 11.25f) /22.5f) - randomDirection) * 22.5f + 11.25f))
            // .Prop("position", new Vector3(transform.position.x + dX , transform.position.y + dY, transform.position.z))
            .Ease(EaseType.EaseInBack));
    }

}
