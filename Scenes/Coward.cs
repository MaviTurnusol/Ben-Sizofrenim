using Godot;
using System;

public class Coward : KinematicBody2D
{
    public static PackedScene Cowardbullet;

    public static Vector2 move;

    static Vector2 dis = new Vector2();

    public float health2 = 3;

    public bool kac = false; 


    public float Health
    {
        get
        {
            return health2;
        }
        set
        {
            health2 = value;
        }
    }

    public override void _Process(float delta)
    {
        var judas = GetNode<Judas>("../Judas");

        move = judas.Position * -1;

        if (kac == true)
        {
            float speed = 200;
            float moveAmount = delta * speed;
            Vector2 MoveDirection = new Vector2(Position.x-judas.Position.x, Position.y-judas.Position.y);
            MoveDirection = MoveDirection.Normalized() * speed;
            MoveDirection = MoveAndSlide(MoveDirection);
        }
        if (health2 <= 0)
        {
            for (int n = 0; n < 8; n++)
            {
                Cowardbullet = (PackedScene)GD.Load("res://Scenes/Cowardbullet.tscn");
                Node2D bulot = (Node2D)Cowardbullet.Instance();
                bulot.Position = Position;
                bulot.RotationDegrees = n * 45;
                GetParent().AddChild(bulot);
            }
            QueueFree();
        }
        if (health2 < 3)
        {
            kac = true;
        }
    }
}
