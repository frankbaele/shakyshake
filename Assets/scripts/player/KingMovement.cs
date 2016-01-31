using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class KingMovement : MonoBehaviour {

    private Animator anim;
    private bool correctInput;
    private Transform pivot;

    //Player progression
    private int level = OUTER_CIRCLE;
    private static int OUTER_CIRCLE = 1;
    private static int MIDDLE_CIRCLE = 2;
    private static int INNER_CIRCLE = 3;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        Events.instance.AddListener<TimerTick>(tick);
        pivot = transform.parent.transform;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void tick(TimerTick e)
    {
        if (/*correctInput*/Input.GetKey(KeyCode.Space) && e.note%2 == 0)
        {
            Debug.Log("King movement");
            HOTween.To(transform, e.interval * 2, new TweenParms()
                .Prop("translation", new Vector3(0, 0, pivot.rotation.eulerAngles.z ))
                .Ease(EaseType.EaseOutBounce));
        }
    }

}
