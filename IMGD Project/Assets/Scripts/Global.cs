using Godot;
using System;

public partial class Global : Node
{
	public bool canPlayerMove = true;
	
	public String currentTask;

	public TextureRect sendEmailCrossed;
	public TextureRect drinkCoffeeCrossed;
	public TextureRect meetingCrossed;
	public TextureRect useToiletCrossed;
	public TextureRect eatSnackCrossed;
	public TextureRect printCrossed;
	public TextureRect introduceCrossed;

	public int tasksCompleted = 0;
	public bool talkedToVeronica = false;

	public static Global Instance;

	public override void _Ready()
	{
		Instance = this;

		sendEmailCrossed = GetNode<TextureRect>("/root/HUD/Expanded_Tasks/send_email_crossed");
		drinkCoffeeCrossed = GetNode<TextureRect>("/root/HUD/Expanded_Tasks/drink_coffee_crossed");
		meetingCrossed = GetNode<TextureRect>("/root/HUD/Expanded_Tasks/attend_meeting_crossed");
		useToiletCrossed = GetNode<TextureRect>("/root/HUD/Expanded_Tasks/use_toilet_crossed");
		eatSnackCrossed = GetNode<TextureRect>("/root/HUD/Expanded_Tasks/get_snack_crossed");
		printCrossed = GetNode<TextureRect>("/root/HUD/Expanded_Tasks/print_documents_crossed");
		introduceCrossed = GetNode<TextureRect>("/root/HUD/Expanded_Tasks/introduce_crossed");
	}
}
