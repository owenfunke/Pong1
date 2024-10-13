using Godot;
using System;


public partial class Ai : StaticBody2D
{
    Vector2 ballPosition;
    int distance;
    float moveDistance;
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
        ballPosition = GetNode<Ball>("/root/Main/MyBalls").Position;
        distance = (int)Position.Y - (int)ballPosition.Y;
        moveDistance = (float)GetNode<Main>("/root/Main").paddleSpeed * (float)delta * (distance/Math.Abs(distance));
        Position -= new Vector2(0, moveDistance);
        Position = new Vector2(Position.X, Mathf.Clamp(Position.Y, halfPaddleHeight, windowHeight - halfPaddleHeight));
    }
}
