using Godot;
using System;

public class Doge : KinematicBody2D
{

    public static new Vector2 moveDirection;

    public static float dashspeed = 500;

    public static Vector2 sex;

    

    public override void _Ready()
    {
        var timer = GetNode<Timer>("Timer");
        timer.Connect("timeout", this, "ontimeout");
    }

    private void OnTimeout()
    {
        QueueFree();
    }

    public override void _Process(float delta)
    {
        var judas = GetNode<Judas>("../Judas");

        sex = judas.Position;

        if (judas.Position.x - Position.x <= 300 && judas.Position.y - Position.y <= 300)
        {
            var timer = GetNode<Timer>("Timer");
            sex = sex.Normalized() * dashspeed;
            sex = MoveAndSlide(sex);
            timer.Start(1);
        }
        else
        {
            float speed = 80;
            float moveAmount = delta * speed;
            Vector2 moveDirection = (judas.Position - Position).Normalized();
            Position += moveDirection * moveAmount;
        } 
    }
}
