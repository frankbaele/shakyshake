using UnityEngine;

public class indicatorEvent : GameEvent {
	public bool correct;
	public string Player;
    // Add event parameters here
	public indicatorEvent(bool correct, string Player)
	{
		this.Player = Player;
		this.correct = correct;
	}
}
