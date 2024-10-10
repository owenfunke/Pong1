using Godot;
using System;

public partial class Ball : CharacterBody2D
{
	/* public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;
 	*/
	public Vector2 windowSize;
	public float startSpeed = 500f;
	public float speed;
	public float acceleration = 50f;
	public Vector2 direction;
	float halfWidth; 
	// Called when the node enters the scene tree for the first time.
	public override void _Ready(){
		windowSize = GetViewport().GetVisibleRect().Size;
		halfWidth = windowSize.X / 2f;
	}

	public void NewBall(){

		GD.Randomize();
		double randomNum = GD.RandRange(200, windowSize.Y - 200f);
		Position = new Vector2(halfWidth, (float)randomNum);
	}
	/* public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	} */
}
