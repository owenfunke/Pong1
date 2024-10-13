using Godot;
using System;
//using System.Numerics;
using System.Collections.Generic;


public partial class Ball : CharacterBody2D
{
    public Vector2 windowSize;
    public float startSpeed = 500f;
    public float speed;
    public float acceleration = 500f;
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
    public override void _PhysicsProcess(double delta)
    {
        var collision = MoveAndCollide(direction * speed * (float)delta);
        if (collision != null){

            var collider = collision.GetCollider();
            Player player = GetNode<Player>("../Player");
            Ai ai = GetNode<Ai>("../AI");
                
            if (collider == player || collider == ai){
                GD.Print("Collision with Player or AI. Increasing speed.");
                speed += acceleration;
                direction = direction.Bounce(collision.GetNormal());
            }
            else{
                direction = direction.Bounce(collision.GetNormal());
                GD.Print("else");
            }
        }
    }
}


