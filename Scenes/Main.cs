using Godot;
using System;


public partial class Main : Sprite2D
{
    int[] score = {0,0};
    public int paddleSpeed = 500;
    private Timer _timer;
    public override void _Ready()
    {
        _timer = GetNode<Timer>("Timer");
        _timer.Timeout += _on_timer_timeout;
    }
    public void _on_timer_timeout(){
        Ball ball = GetNode<Ball>("MyBalls");
        ball.NewBall();
    }
}
