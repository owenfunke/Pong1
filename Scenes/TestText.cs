using Godot;
using System;

public partial class TestText : Label
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		/* var parentNode = (Main)GetParent();
		GD.Randomize();
		double randomNum = GD.RandRange(200, 500f);
		Vector2 gmm = new Vector2(50, (float)randomNum); */
		
		Text = GetNode<Ball>("/root/Main/MyBalls").speed.ToString();
	}
}
