using Godot;
using System;
using System.Threading;

public partial class HUD : CanvasLayer
{
	Global global;
	TextureRect taskList;
	TextureButton taskButton;

	// Tasks:
	// think about making this arrays or something better instead.. hardcoding it sucks
	TextureRect sendEmailCrossed;
	TextureRect drinkCoffeeCrossed;

	ColorRect fade;
	
	bool canPlayerMove;

	bool taskList_open = false;

	bool clock = false;
	
	public override void _Ready() 
	{
		global = GetNode<Global>("/root/Global");
		taskList = GetNode<TextureRect>("Expanded_Tasks");
		taskButton = GetNode<TextureButton>("TaskButton");
		fade = GetNode<ColorRect>("Fade");
		canPlayerMove = global.canPlayerMove;
		sendEmailCrossed = GetNode<TextureRect>("/root/HUD/Expanded_Tasks/send_email_crossed");
		drinkCoffeeCrossed = GetNode<TextureRect>("/root/HUD/Expanded_Tasks/drink_coffee_crossed");
	}

	private void _on_task_button_pressed()
	{
		if (taskList_open == true) {
			taskList.Visible = false;
			taskList_open = false;
			canPlayerMove = true;
		}
		else {
			taskList.Visible = true;
			taskList_open = true;
			canPlayerMove = false;
		}

		//fadeBackground(fade, taskList_open);
	}

	private void _on_complete_task_button_pressed()
	{
		GD.Print("Completed task!");
		GD.Print(global.currentTask);

		if (global.currentTask == "send_email") {
			sendEmailCrossed.Visible = true;
		}
		else if (global.currentTask == "drink_coffee") {
			drinkCoffeeCrossed.Visible = true;
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		clock = true;
		clock = false;
	}

	private void fadeBackground(ColorRect itemToFade, bool fadeIn)
	{
		int num;
		int fullFade = 130;
		int noFade = 0;
		int secondsToFade = 2;

		if (!fadeIn) { //if fading out
			float i = 0;
			while(i < secondsToFade) {
				while(!clock) {
					//wait for 1/60 for clock to flip
				}

				i += .0166f * secondsToFade;
				//itemToFade.modulate.a = (int) (fullFade * (1 - i * fullFade));
			}
			num = fullFade;
		}
		else {
			num = noFade;
		}

		for (int i = 0; i < num; i++) {
			//itemToFade.Modulate = num;
			
		}
	}
}
