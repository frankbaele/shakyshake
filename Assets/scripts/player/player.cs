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
	GameObject shaman;
	Queue<int[]> queue = new Queue<int[]>();

    //Player progression
	public int points = 0;

    void Start()
	{
		Events.instance.AddListener<TimerTick>(tick);
		shaman = transform.Find("Shaman").gameObject;
		// quickly add 4 empty commands
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
			if (Input.GetButtonDown("Up_" + id)){
				inputArray[idxUp] = true;
			}
			if (Input.GetButtonDown("Down_" + id))
				inputArray[idxDown] = true;
			if (Input.GetButtonDown("Left_" + id))
				inputArray[idxLeft] = true;
			if (Input.GetButtonDown("Right_" + id))
				inputArray[idxRight] = true;
		}
		var vert = Input.GetAxis("Vertical_" + id);
		if(vert == 1){
			inputArray[idxUp] = true;
		} else if( vert == -1){
			inputArray[idxDown] = true;
		} 
		var hori = Input.GetAxis("Horizontal_" + id);
		if(hori == -1 ){
			inputArray[idxLeft] = true;
		} else if( hori == 1){
			inputArray[idxRight] = true;
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
	
	void addCommand(float wait){
		var rNumbers = randomNumbers(Random.Range(1,4));
		var rStrings = stringInput(rNumbers);
		for(int i = 0; i < rStrings.Length; i++){
			var x = 0;
			var y = 0;
			
			if(rStrings[i] == "left"){
				x = -1;
			}
			if(rStrings[i] == "right"){
				x = 1;
			}
			if(rStrings[i] == "up"){
				y = 1;
			}
			if(rStrings[i] == "down"){
				y = -1;
			}
			Events.instance.Raise(new DiscFired(shaman.transform.position, new Vector2(x,y), wait));
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
		
		for(var i = 0; i < inputArray.Length; i++)
		{
			if(!inputArray[i]){
				//correct = false;
			}
		}
		// otherwise no action is requiered
		if(firstElement.Length > 0){
			if(correct){
				points++;
			} else {
				points--;
				points = points < 0 ? 0:points;
			}
		}
		resetInput();	
	}
	
	void tick(TimerTick e){
		if(e.note%4 == 0){
			addCommand(e.interval*4f);
			checkCommand();
		}
	}

	public int getCurrentPoints()
    {
	    return points;
    }
}
