using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class Player : MonoBehaviour
{
	public string id;

    //Player input
	bool[] inputArray = new bool[4];
	int idxUp = 0;
	int idxDown = 1;
	int idxLeft = 2;
	int idxRight = 3;
	bool dpadVertPressed = false;
	bool dpadHorzPressed = false;
	Queue<int[]> queue = new Queue<int[]>();

    //Player progression
    private int level = OUTER_CIRCLE;
    private static int OUTER_CIRCLE = 1;
    private static int MIDDLE_CIRCLE = 2;
    private static int INNER_CIRCLE = 3;

    void Start()
	{
		Events.instance.AddListener<TimerTick>(tick);
		
		// quickly add 4 empty commands
		queue.Enqueue(new int[0]);
		queue.Enqueue(new int[0]);
		queue.Enqueue(new int[0]);
		queue.Enqueue(new int[0]);
	}
	
	void Update()
	{
		checkInput();
	}
	
	void resetInput(){
		for(int i = 0; i < inputArray.Length; i++){
			inputArray[i] = false;
		}
	}
	
	void checkInput(){
		if(Input.anyKey)
		{
			if (Input.GetButtonDown("Up_" + id))
				inputArray[idxUp] = true;
			if (Input.GetButtonDown("Down_" + id))
				inputArray[idxDown] = true;
			if (Input.GetButtonDown("Left_" + id))
				inputArray[idxLeft] = true;
			if (Input.GetButtonDown("Right_" + id))
				inputArray[idxRight] = true;
		}
		var dpadVert = Input.GetAxis("Vertical_" + id);
		if(dpadVert == 1 && !dpadVertPressed){
			inputArray[idxUp] = true;
			dpadVertPressed = true;
		} else if( dpadVert == -1 && !dpadVertPressed){
			inputArray[idxDown] = true;
			dpadVertPressed = true;
		} else if(dpadVert == 0){
			dpadVertPressed = false;
		}
		var dpadHor = Input.GetAxis("Horizontal_" + id);
		if(dpadHor == -1 && !dpadHorzPressed){
			inputArray[idxLeft] = true;
			dpadHorzPressed = true;
		} else if( dpadHor == 1&& !dpadHorzPressed){
			inputArray[idxRight] = true;
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
	
	void addCommand(){
		var rNumbers = randomNumbers(1);
		var rStrings = stringInput(rNumbers);
		for(int i = 0; i < rStrings.Length; i++){
			Debug.Log(rStrings[i]);
		}
		queue.Enqueue(rNumbers);
	}
	
	string[] stringInput(int[] numbers){
		string[] input = new string[numbers.Length];
		
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
	
	void checkCommand()
	{

		var firstElement = queue.Dequeue();
		bool correct = true;
		
		for(var i = 0; i < firstElement.Length; i++)
		{
			if(!inputArray[firstElement[i]]){
				correct = false;
			}
			inputArray[firstElement[i]] = false;
		}
			/*
			for(var i = 0; i < inputArray.Length; i++)
			{
				if(!inputArray[i]){
					correct = false;
				}
			}
			*/
		Debug.Log(correct);
		resetInput();
		
	}
	
	void tick(TimerTick e){
		if(e.note%4 == 0){
			addCommand();
			checkCommand();
		}
	}
}
