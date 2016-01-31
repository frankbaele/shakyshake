using UnityEngine;
using System.Collections;
using Holoville.HOTween;
public class Disc : MonoBehaviour
{
	public float speed = 0f;
	public Sprite arrowPassive;
	public Sprite arrowActive;
	public bool destroyed = false;
	public System.Guid guid = System.Guid.NewGuid();

	void Awake()
	{

		Events.instance.AddListener<TimerTick>(tick);
	}
	
	public void fireDisc(Vector2 position, Vector2 velocity, float time)
	{
		transform.position = position;
		var rotate = 0;
		var temp = velocity * speed;
		if(velocity.x == 1){
			rotate = 270;
		} 
		if(velocity.x == -1){
			rotate = 90;
		}
		if(velocity.y == -1){
			rotate = 180;
		}
		
		transform.Rotate(0, 0, rotate);
		HOTween.To(gameObject.transform, time, new TweenParms()
			.Prop("position", new Vector3(position.x + temp.x, position.y + temp.y, 0))
			.Ease(EaseType.Linear)
			.OnComplete(()=>{
				destroyed = true;
				Events.instance.RemoveListener<TimerTick>(tick);
				})
		);

	}
	void tick(TimerTick e)
	{
		GetComponent<SpriteRenderer>().sprite = arrowPassive;
		if(e.note%2 == 0){
			GetComponent<SpriteRenderer>().sprite = arrowActive;
		}

	}

}
