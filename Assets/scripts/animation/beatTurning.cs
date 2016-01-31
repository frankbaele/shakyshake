using UnityEngine;
using System.Collections;
using Holoville.HOTween;

public class beatTurning : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Events.instance.AddListener<TimerTick>(tick);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void tick (TimerTick e){
		if(e.note%2 == 0){
			HOTween.To(transform, e.interval*2, new TweenParms()
				.Prop("rotation", new Vector3(0,0, gameObject.transform.rotation.eulerAngles.z + (15 * (Random.Range(0,3) - 1))))
				.Ease(EaseType.EaseOutBounce));
		}

	}
}
