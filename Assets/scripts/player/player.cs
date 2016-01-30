using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class Player : MonoBehaviour
{
	public string id;
	bool left = false;
	bool right = false;
	bool up = false;
	bool down = false;
	bool dpadVertPressed = false;
	bool dpadHorzPressed = false;
	List<string[]> queue = new List<string[]>();
	void Start()
	{
		Events.instance.AddListener<TimerTick>(tick);
		// quickly add 4 empty commands
		queue.Add(new string[0]);
		queue.Add(new string[0]);
		queue.Add(new string[0]);
		queue.Add(new string[0]);
	}
	
	void Update()
	{
		checkInput();
	}
	
	void checkInput(){
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
		if(dpadVert == 1 && !dpadVertPressed){
			up = true;
			dpadVertPressed = true;
		} else if( dpadVert == -1 && !dpadVertPressed){
			down = true;
			dpadVertPressed = true;
		} else if(dpadVert == 0){
			dpadVertPressed = false;
		}
		var dpadHor = Input.GetAxis("Horizontal_" + id);
		if(dpadHor == -1 && !dpadHorzPressed){
			left = true;
			dpadHorzPressed = true;
		} else if( dpadHor == 1&& !dpadHorzPressed){
			right = true;
			dpadHorzPressed = true;
		} else if(dpadHor == 0){
			dpadHorzPressed = false;
		}
	}
	
	int[] randomNumbers(int number){
		List<int> numbers = new List<int>();
		for (var i = 0; i < 4; i++) {
			numbers.Add(i);
		}
		var randomNumbers = new int[number];
		for (var i = 0; i < randomNumbers.Length; i++) {
			var thisNumber = Random.Range(0, numbers.Count);
			randomNumbers[i] = numbers[thisNumber];
			numbers.RemoveAt(thisNumber);
		}
		return randomNumbers;
	}

	string[] randomInput(int number){
		var numbers = randomNumbers(number);
		string[] input = new string[number];
		
		for(var i = 0; i< numbers.Length; i++){
			switch (numbers[i])
			{
			case 0:
				input[i] = "up";
				break;
			case 1:
				input[i] = "down";
				break;
			case 2:
				input[i] = "left";
				break;
			default:
				input[i] = "right";
				break;
			}
		}
		return input;
	}
	void addCommand(){
		queue.Add(randomInput(1));
	}
	void checkCommand(){
		var lastElement = queue.Last();
	}
	void tick(TimerTick e){
		if(e.note%4 == 0){
			addCommand();
			checkCommand();
		}
	}
}
