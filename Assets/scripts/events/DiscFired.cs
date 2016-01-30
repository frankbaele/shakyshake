using UnityEngine;
public class DiscFired : GameEvent
{
	
	public Vector2 velocity;
	public Vector2 position;
    // Add event parameters here
	public DiscFired(Vector2 pos, Vector2 vel)
	{
		velocity = vel;
		position = pos;
	}
}
