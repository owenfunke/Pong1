using Godot;
using System;

public partial class Vignette : Sprite2D
{
	private Ball _ball;
	public float alpha =  0.5f;
	 private float targetAlpha = 0.5f;
    private float lerpSpeed = 0.1f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_ball = GetNode<Ball>("../MyBalls");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		alpha = (_ball.speed - 500) / 500;
		alpha = Mathf.Lerp(alpha, targetAlpha, lerpSpeed);
		Modulate = new Color(Modulate.R , Modulate.G , Modulate.B , alpha);
	}
}
