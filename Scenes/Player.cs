using Godot;
using System;
using System.Numerics;
using System.Runtime.InteropServices;

public partial class Player : StaticBody2D
{
	int windowHeight;
	int paddleHeight;
	int halfPaddleHeight;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		windowHeight = (int)GetViewport().GetVisibleRect().Size.Y;
		paddleHeight = (int)GetNode<ColorRect>("ColorRect").Size.Y;
		halfPaddleHeight = paddleHeight/2;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var parentNode = (Main)GetParent();
		if (Input.IsActionPressed("ui_up"))
		{
			Position -= new Godot.Vector2(0, parentNode.paddleSpeed * (float)delta);
		}
		else if (Input.IsActionPressed("ui_down"))
		{
			// Move the paddle down
			Position += new Godot.Vector2(0, parentNode.paddleSpeed * (float)delta);
		}
		Position = new Godot.Vector2(Position.X, Mathf.Clamp(Position.Y, halfPaddleHeight, windowHeight - halfPaddleHeight));
	}
}
