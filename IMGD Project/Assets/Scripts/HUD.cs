using Godot;
using System;
using System.Threading;

public partial class HUD : CanvasLayer
{
	TextureRect taskList;
	TextureButton taskButton;
	ColorRect fade;
	
	bool playerCanMove = true;

	bool taskList_open = false;

	bool clock = false;
	
	public override void _Ready() 
	{
		taskList = GetNode<TextureRect>("Expanded_Tasks");
		taskButton = GetNode<TextureButton>("TaskButton");
		fade = GetNode<ColorRect>("Fade");
	}

	private void _on_task_button_pressed()
	{
		if (taskList_open == true) {
			taskList.Visible = false;
			taskList_open = false;
			playerCanMove = true;
		}
		else {
			taskList.Visible = true;
			taskList_open = true;
			playerCanMove = false;
		}

		//fadeBackground(fade, taskList_open);
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
