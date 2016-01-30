using UnityEngine;
using InControl;
using System.Collections;
public class Player : MonoBehaviour
{
	public int id;
	void Start()
	{
		Events.instance.AddListener<TimerTick>(tick);
	}
	
	void Update()
	{
		
	}
	void tick(TimerTick e){
		
	}
}
