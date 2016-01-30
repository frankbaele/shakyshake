using UnityEngine;
using System.Collections;
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
	
	public void fireDisc(Vector2 position, Vector2 velocity)
	{
		rb.transform.position = position;
		rb.velocity = velocity * speed;
		discRend.enabled = true;
	}

}
