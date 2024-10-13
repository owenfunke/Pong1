using Godot;
using System;
//using System.Numerics;
using System.Collections.Generic;
//using System.Numerics;


public partial class Ball : CharacterBody2D
{
    public Vector2 windowSize;
    public float startSpeed = 500f;
    public float speed;
    public float acceleration = 50f;
    public Vector2 direction;
    public const float MaxYVector = 0.6f;
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
        speed = startSpeed;
        direction = RandDirection();
    }

    public Vector2 RandDirection(){
        Vector2 newdir = new Vector2();
        int[] directions = {1, -1};
        newdir.X = directions[GD.Randi() % 2];
        newdir.Y = (float)GD.RandRange(-1, 1);
        return newdir.Normalized();
    }
    public Vector2 NewDirection(GodotObject collider){
        float ball_y = Position.Y;
        float paddle_y = 0;
        float halfPaddleHeight = 0;
        Vector2 newdir = new Vector2();
        Node2D colliderNode = collider as Node2D;
        // Check if collider is Player
        if (collider is Player player)
        {
            paddle_y = player.Position.Y;
            halfPaddleHeight = player.halfPaddleHeight;
            GD.Print("Player");
        }
        // Check if collider is Ai
        else if (collider is Ai ai)
        {
            paddle_y = ai.Position.Y;
            halfPaddleHeight = ai.halfPaddleHeight;
            GD.Print("Ai");
        }
        else
        {
            GD.Print("Collider is neither Player nor Ai");
            return newdir;
        }
        float distance = ball_y - paddle_y;
        GD.Print("Ball Y: ", ball_y, " Paddle Y: ", paddle_y, " Distance: ", distance);
        if (colliderNode.Position.X > halfWidth){
            newdir.X = -1;
        }
        else{
            newdir.X = 1;
        }
        newdir.Y = (distance / halfPaddleHeight) * MaxYVector;
        direction = newdir.Normalized();
        GD.Print("New Direction: ", direction);
        return direction;
    }
    public override void _PhysicsProcess(double delta)
    {
        var collision = MoveAndCollide(direction * speed * (float)delta);
        if (collision != null){

            GodotObject collider = collision.GetCollider();
            Player player = GetNode<Player>("../Player");
            Ai ai = GetNode<Ai>("../AI");
                
            if (collider == player || collider == ai){
                GD.Print("Collision with Player or AI. Increasing speed.");
                speed += acceleration;
                direction = NewDirection(collider);
            }
            else{
                direction = direction.Bounce(collision.GetNormal());
                GD.Print("else");
            }
        }
    } 
}


