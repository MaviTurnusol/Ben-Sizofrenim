using Godot;
using System;

public class Doge : KinematicBody2D
{

    public static new Vector2 moveDirection;

    public static float dashspeed = 500;

    public static Vector2 sex;

    

    public override void _Ready()
    {
        
    }


    public override void _Process(float delta)
    {
        var judas = GetNode<Judas>("../Judas");

        sex = judas.Position;

        if (judas.Position.x - Position.x <= 300 && judas.Position.y - Position.y <= 300)
        {
            sex = sex.Normalized() * dashspeed;
            sex = MoveAndSlide(sex);
        }
        else
        {
            float speed = 80;
            float moveAmount = delta * speed;
            Vector2 moveDirection = (judas.Position - Position).Normalized();
            Position += moveDirection * moveAmount;
        } 
        if (Position == judas.Position)
        {
            QueueFree();
        }
    }
}
