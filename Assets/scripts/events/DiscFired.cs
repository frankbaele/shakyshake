using UnityEngine;
public class DiscFired : GameEvent
{
	
	public Vector2 velocity;
	public Vector2 position;
	public float time;
    // Add event parameters here
	public DiscFired(Vector2 pos, Vector2 vel, float time)
	{
		velocity = vel;
		position = pos;
		this.time = time;
	}
}
