using UnityEngine;
using System.Collections;

public class TimerTick : GameEvent {
	public int note;
	public int bpm;
	public float interval;
	public TimerTick(int note, int bpm, float interval)
	{
		this.note = note;
		this.bpm = bpm;
		this.interval = interval;
	}
}


