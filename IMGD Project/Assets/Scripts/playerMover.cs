using Godot;
using System;

public partial class playerMover : CharacterBody2D
{
	private Texture _upTexture;
	private Texture _downTexture;
	private Texture _leftTexture;
	private Texture _rightTexture;

	public override void _Ready()
	{
		_upTexture = GD.Load<Texture>("res://Assets/CharacterSprites/Player-002.png");
		_downTexture = GD.Load<Texture>("res://Assets/CharacterSprites/Player-001.png");
		_leftTexture = GD.Load<Texture>("res://Assets/CharacterSprites/Player-003.png");
		_rightTexture = GD.Load<Texture>("res://Assets/CharacterSprites/Player-004.png");
	}

	protected virtual void _PhysicsProcess(float delta)
	{
		Vector2 velocity = Vector2.Zero;

		if (Input.IsActionPressed("move_right"))
		{
			velocity.x += 1;
			SetTexture(_rightTexture);
		}
		else if (Input.IsActionPressed("move_left"))
		{
			velocity.x -= 1;
			SetTexture(_leftTexture);
		}

		if (Input.IsActionPressed("move_down"))
		{
			velocity.y += 1;
			SetTexture(_downTexture);
		}
		else if (Input.IsActionPressed("move_up"))
		{
			velocity.y -= 1;
			SetTexture(_upTexture);
		}

		MoveAndSlide();
	}

	private void SetTexture(Texture texture)
	{
		Sprite sprite = GetNode<Sprite>("Sprite");
		if (sprite != null)
		{
			sprite.Texture = texture;
		}
		else
		{
			GD.Print("Sprite node not found!");
		}
	}
}
