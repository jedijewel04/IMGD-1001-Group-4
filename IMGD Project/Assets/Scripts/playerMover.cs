using Godot;
using System;

public partial class playerMover : CharacterBody2D
{
	public int WalkSpeed { get; set; } = 100;
	public int SprintSpeed { get; set; } = 200;
	
	private AnimationPlayer _animationPlayer;

	public override void _Ready()
	{
		_animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}
	
	public void GetInput()
	{
		Vector2 inputDirection = Input.GetVector("move_left", 
												"move_right", 
												"move_up", 
												"move_down");
												
		if (Input.IsActionPressed("sprint")) Velocity = inputDirection * SprintSpeed;
		else Velocity = inputDirection * WalkSpeed;
	}

	public override void _PhysicsProcess(double  _delta)
	{
		// Move the player:
		GetInput();
		MoveAndSlide();
		
		// Update the animations:
		if (Input.IsActionPressed("move_down")) 
		{
			_animationPlayer.Play("WalkDown");
		}
		else if (Input.IsActionPressed("move_up")) 
		{
			_animationPlayer.Play("WalkUp");
		}
		else if (Input.IsActionPressed("move_right")) 
		{
			_animationPlayer.Play("WalkRight");
		}
		else if (Input.IsActionPressed("move_left")) 
		{
			_animationPlayer.Play("WalkLeft");
		}
		else 
		{
			_animationPlayer.Stop();
		}
	}
}
