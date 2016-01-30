using UnityEngine;
using System.Collections;
public class Player : MonoBehaviour
{
	public string id;
	bool left = false;
	bool right = false;
	bool up = false;
	bool down = false;
	void Start()
	{
		Events.instance.AddListener<TimerTick>(tick);
	}
	
	void Update()
	{
		left = false;
		right = false;
		up = false;
		down = false;
		
		if(Input.anyKey)
		{
			if (Input.GetButtonDown("Up_" + id))
				up = true;
			if (Input.GetButtonDown("Down_" + id))
				down = true;
			if (Input.GetButtonDown("Left_" + id))
				left = true;
			if (Input.GetButtonDown("Right_" + id))
				right = true;
		}
		var dpadVert = Input.GetAxis("Vertical_" + id);
		if(dpadVert == 1){
			up = true;
		} else if( dpadVert == -1){
			down = true;
		}
		var dpadHor = Input.GetAxis("Horizontal_" + id);
		if(dpadHor == -1){
			left = true;
		} else if( dpadHor == 1){
			right = true;
		}
		if(left){
			Debug.Log("left");
		}
		if(right){
			Debug.Log("right");
		}
		if(up){
			Debug.Log("up");
		}
		if(down){
			Debug.Log("down");
		}
	}

	void tick(TimerTick e){
		
	}
}
