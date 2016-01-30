using System;
using InControl;

public class PlayerActions : PlayerActionSet
{
	public PlayerAction Fire;
	public PlayerAction Dash;
	public PlayerAction Left;
	public PlayerAction Right;
	public PlayerAction Up;
	public PlayerAction Down;
	public PlayerTwoAxisAction Move;
	
	
	public PlayerActions()
	{
		Fire = CreatePlayerAction( "Fire" );
		Dash = CreatePlayerAction( "Dash" );
		Left = CreatePlayerAction( "Move Left" );
		Right = CreatePlayerAction( "Move Right" );
		Up = CreatePlayerAction( "Move Up" );
		Down = CreatePlayerAction( "Move Down" );
		Move = CreateTwoAxisPlayerAction( Left, Right, Down, Up );
	}
	
	
	public static PlayerActions CreateWithKeyboardBindings()
	{
		var actions = new PlayerActions();
		actions.Fire.AddDefaultBinding( Key.Shift, Key.A );
		actions.Fire.AddDefaultBinding( Key.Space );
		actions.Up.AddDefaultBinding( Key.UpArrow );
		actions.Down.AddDefaultBinding( Key.DownArrow );
		actions.Left.AddDefaultBinding( Key.LeftArrow );
		actions.Right.AddDefaultBinding( Key.RightArrow );
		
		return actions;
	}
	
	
	public static PlayerActions CreateWithJoystickBindings()
	{
		var actions = new PlayerActions();
		actions.Fire.AddDefaultBinding( InputControlType.Action1 );
		actions.Dash.AddDefaultBinding( InputControlType.Action3 );
		actions.Dash.AddDefaultBinding( InputControlType.Back );
		actions.Dash.AddDefaultBinding( InputControlType.System );
		
		actions.Left.AddDefaultBinding( InputControlType.LeftStickLeft );
		actions.Right.AddDefaultBinding( InputControlType.LeftStickRight );
		actions.Up.AddDefaultBinding( InputControlType.LeftStickUp );
		actions.Down.AddDefaultBinding( InputControlType.LeftStickDown );
		
		return actions;
	}
}
