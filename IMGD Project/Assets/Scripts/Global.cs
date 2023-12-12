using Godot;
using System;

public partial class Global : Node
{
	public bool canPlayerMove = true;
	
	public String currentTask;

	public static Global Instance;

	public override void _Ready()
	{
		Instance = this;
	}
}
