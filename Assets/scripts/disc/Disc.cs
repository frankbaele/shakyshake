using UnityEngine;
using System.Collections;
using Holoville.HOTween;
public class Disc : MonoBehaviour
{
	public float speed = 0f;
	public bool destroyed = false;
	public System.Guid guid = System.Guid.NewGuid();
	private Rigidbody2D rb;
	private Renderer discRend;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		discRend = GetComponent<Renderer>();
		discRend.enabled = false;
	}
	
	public void fireDisc(Vector2 position, Vector2 velocity, float time)
	{
		rb.transform.position = position;
		//rb.velocity = velocity * speed;
		var temp = velocity * speed;
		HOTween.To(rb.transform, time, new TweenParms()
			.Prop("position", new Vector3(position.x + temp.x, position.y + temp.y, 0))
			.Ease(EaseType.Linear)
			.OnComplete(()=>{
					destroyed = true;
				})
		);
		discRend.enabled = true;
	}

}
