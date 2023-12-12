using Godot;
using System;

public partial class playerMover : CharacterBody2D
{
	Global global;
	public int WalkSpeed { get; set; } = 100;
	public int SprintSpeed { get; set; } = 200;
	bool canPlayerMove;
	private AnimationPlayer _animationPlayer;
	private TextureButton completeTaskButton;

	public override void _Ready()
	{
		global = GetNode<Global>("/root/Global");
		_animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		canPlayerMove = global.canPlayerMove;
		Node HUD = GetNode("/root/HUD");
		completeTaskButton = HUD.GetNode<TextureButton>("CompleteTaskButton");
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
		if (canPlayerMove) {
			// Move the player:
			GetInput();
			MoveAndSlide();
			
			// Update the animations:
			if (Input.IsActionPressed("move_down")) 
			{
				_animationPlayer.Play("PlayerAnimations/WalkDown");
			}
			else if (Input.IsActionPressed("move_up")) 
			{
				_animationPlayer.Play("PlayerAnimations/WalkUp");
			}
			else if (Input.IsActionPressed("move_right")) 
			{
				_animationPlayer.Play("PlayerAnimations/WalkRight");
			}
			else if (Input.IsActionPressed("move_left")) 
			{
				_animationPlayer.Play("PlayerAnimations/WalkLeft");
			}
			else 
			{
				_animationPlayer.Stop();
			}
		}
	}

	private void body_entered(String currTask) {
		completeTaskButton.Visible = true;
		global.currentTask = currTask;
	}

	private void body_exited() {
		completeTaskButton.Visible = false;
		global.currentTask = null;
	}
	
	private void _on_computer_task_body_entered(Node2D body) { body_entered("send_email"); }
	private void _on_computer_task_body_exited(Node2D body) { body_exited(); }

	private void _on_coffee_task_body_entered(Node2D body) { body_entered("drink_coffee"); }
	private void _on_coffee_task_body_exited(Node2D body) { body_exited(); }

	private void _on_meeting_task_body_entered(Node2D body) { body_entered("meeting"); }
	private void _on_meeting_task_body_exited(Node2D body) { body_exited(); }

	private void _on_toilet_task_body_entered(Node2D body) { body_entered("use_toilet"); }
	private void _on_toilet_task_body_exited(Node2D body) { body_exited(); }
}



