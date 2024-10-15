using Godot;
using System;


public partial class Main : Sprite2D
{
    int[] score = {0,0};
    public int paddleSpeed = 500;
    private Timer _timer;
    private Area2D _scoreleft;
    private Area2D _scoreright;
    public override void _Ready()
    {
        _timer = GetNode<Timer>("Timer");
        _timer.Timeout += _on_timer_timeout;
        _scoreleft = GetNode<Area2D>("ScoreLeft");
        _scoreright = GetNode<Area2D>("ScoreRight");
        //_scoreleft.Connect("body_entered", new Callable(this, nameof(_on_score_left_body_entered)));
        //_scoreright.Connect("body_entered", new Callable(this, nameof(_on_score_right_body_entered)));
        _scoreleft.BodyEntered += _on_score_left_body_entered; 
        _scoreright.BodyEntered += _on_score_right_body_entered;
    }
    public void _on_timer_timeout(){
        Ball ball = GetNode<Ball>("MyBalls");
        ball.NewBall();
    }
    public void _on_score_left_body_entered(Node body){
        score[1]++;
        GetNode<CanvasLayer>("HeadsUpDisplay").GetNode<Label>("AIScore").Text = score[1].ToString();
        _timer.Start();
    }
    public void _on_score_right_body_entered(Node body){
        score[0]++; 
        GetNode<CanvasLayer>("HeadsUpDisplay").GetNode<Label>("Score").Text = score[0].ToString();
        _timer.Start();
    }
}
