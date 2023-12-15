using Godot;
using System;
using System.Threading;

public partial class HUD : CanvasLayer
{
	Global global;
	TextureRect taskList;
	TextureButton taskButton;

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
		if (global.currentTask != "talk_to_veronica") {
			if (global.currentTask == "send_email") {
				global.sendEmailCrossed.Visible = true;
			}
			else if (global.currentTask == "drink_coffee") {
				global.drinkCoffeeCrossed.Visible = true;
			}
			else if (global.currentTask == "meeting") {
				global.meetingCrossed.Visible = true;
			}
			else if (global.currentTask == "use_toilet") {
				global.useToiletCrossed.Visible = true;
			}
			else if (global.currentTask == "eat_snack") {
				global.eatSnackCrossed.Visible = true;
			}
			else if (global.currentTask == "print") {
				global.printCrossed.Visible = true;
			}
			global.tasksCompleted += 1;
		}
	}

	private void _on_speak_button_pressed()
	{
		if (global.currentTask == "talk_to_veronica") {
			Node2D myGDScriptNode = GetNode<Node2D>("/root/Dialogue");
			myGDScriptNode.Call("_startVeronicaDialog", global.tasksCompleted);
			global.talkedToVeronica = true;
		}
		else if (global.currentTask == "talk_to_zayn") {
			if (global.talkedToVeronica == true && global.introduceCrossed.Visible == false) {
				global.introduceCrossed.Visible = true;
				global.tasksCompleted += 1;
			}
			Node2D myGDScriptNode = GetNode<Node2D>("/root/Dialogue");
			myGDScriptNode.Call("_startZaynDialog");
		}
		else if (global.currentTask == "talk_to_zoe") {
			if (global.talkedToVeronica == true && global.introduceCrossed.Visible == false) {
				global.introduceCrossed.Visible = true;
				global.tasksCompleted += 1;
			}
			Node2D myGDScriptNode = GetNode<Node2D>("/root/Dialogue");
			myGDScriptNode.Call("_startZoeDialog");
		}
		else if (global.currentTask == "talk_to_dog") {
			Node2D myGDScriptNode = GetNode<Node2D>("/root/Dialogue");
			myGDScriptNode.Call("_startDogDialog");
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
