using Godot;
using System;

public partial class ClickableArea : CollisionShape2D
{
	/*
	[Export] int test = 1;
	// Signal to emit when the area is clicked
	[Signal]
	public delegate void AreaClicked();

	public override void _Ready()
	{
		// Connect the area's signal to a method
		Connect("input_event", this, "_on_InputEvent");
	}

	// Input event handler
	private void _on_InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
	{
		// Check if the input event is a mouse button press
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == (int)ButtonList.Left)
		{
			// Emit the signal when the area is clicked
			EmitSignal("AreaClicked");
		}
	}
	*/
}
