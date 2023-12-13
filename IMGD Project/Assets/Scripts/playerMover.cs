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
	private TextureButton speakButton;

	public override void _Ready()
	{
		global = GetNode<Global>("/root/Global");
		_animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		canPlayerMove = global.canPlayerMove;
		Node HUD = GetNode("/root/HUD");
		completeTaskButton = HUD.GetNode<TextureButton>("CompleteTaskButton");
		speakButton = HUD.GetNode<TextureButton>("speakButton");

		completeTaskButton.Visible = false;
		speakButton.Visible = false;
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

	private void body_entered_helper(String currTask) {
		completeTaskButton.Visible = true;
		global.currentTask = currTask;
	}

	private void body_exited_helper() {
		completeTaskButton.Visible = false;
		global.currentTask = null;
	}
	
	private void _on_computer_task_body_entered(Node2D body) 
	{ 
		if (global.talkedToVeronica == true) {
			if (global.sendEmailCrossed.Visible == false) body_entered_helper("send_email"); 
		}
	}
	private void _on_computer_task_body_exited(Node2D body) { body_exited_helper(); }

	private void _on_coffee_task_body_entered(Node2D body) 
	{ 
		if (global.talkedToVeronica == true) {
			if (global.drinkCoffeeCrossed.Visible == false) body_entered_helper("drink_coffee");
		}
	}
	private void _on_coffee_task_body_exited(Node2D body) { body_exited_helper(); }

	private void _on_meeting_task_body_entered(Node2D body) 
	{ 
		if (global.talkedToVeronica == true) {
			if (global.meetingCrossed.Visible == false) body_entered_helper("meeting");
		}
	}
	private void _on_meeting_task_body_exited(Node2D body) { body_exited_helper(); }

	private void _on_toilet_task_body_entered(Node2D body) 
	{ 
		if (global.talkedToVeronica == true) {
			if (global.useToiletCrossed.Visible == false) body_entered_helper("use_toilet"); 
		}
	}
	private void _on_toilet_task_body_exited(Node2D body) { body_exited_helper(); }

	private void _on_snack_task_body_entered(Node2D body) 
	{ 
		if (global.talkedToVeronica == true) {
			if (global.eatSnackCrossed.Visible == false) body_entered_helper("eat_snack"); 
		}
	}
	private void _on_snack_task_body_exited(Node2D body) { body_exited_helper(); }

	private void _on_printer_task_body_entered(Node2D body) 
	{ 
		if (global.talkedToVeronica == true) {
			if (global.printCrossed.Visible == false) body_entered_helper("print");
		}
	}
	private void _on_printer_task_body_exited(Node2D body) { body_exited_helper(); }
	
	// Veronica:
	private void _on_area_2d_body_entered(Node2D body)
	{
		//if (global.introduceCrossed.Visible == false) {
		//	body_entered_helper("talk_to_veronica");
		//}
		//else {
			speakButton.Visible = true;
			global.currentTask = "talk_to_veronica";
		//}
	}
	private void _on_area_2d_body_exited(Node2D body)
	{
		body_exited_helper();
		speakButton.Visible = false;
	}

	// Zayn:
	
	private void _on_zayn_body_entered(Node2D body)
	{
		speakButton.Visible = true;
		global.currentTask = "talk_to_zayn";
	}
	private void _on_zayn_body_exited(Node2D body)
	{
		body_exited_helper();
		speakButton.Visible = false;
	}
	
	private void _on_zoe_body_entered(Node2D body)
	{
		speakButton.Visible = true;
		global.currentTask = "talk_to_zoe";
	}
	private void _on_zoe_body_exited(Node2D body)
	{
		body_exited_helper();
		speakButton.Visible = false;
	}

	private void _on_entrance_to_office_body_entered(Node2D body)
	{
		GD.Print("hello");
		GetTree().ChangeSceneToFile("res://Scenes/Office.tscn");
	}
}
