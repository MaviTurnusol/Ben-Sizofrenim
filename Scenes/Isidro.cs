using Godot;
using System;

public class Isidro : KinematicBody2D
{
    public static PackedScene Cowardbullet;

    public static Vector2 move;

    public static bool shoot = true;

    public static bool kac = false;

    public float health3 = 3;


    public float Health
    {
        get
        {
            return health3;
        }
        set
        {
            health3 = value;
        }
    }
    public override void _Ready()
    {
        Timer timer = this.GetNode<Timer>("Timer");
        timer.WaitTime = 2;
        timer.Connect("timeout", this, "on_timeout");
        timer.Start();
        Timer timer2 = this.GetNode<Timer>("Timer");
        timer2.WaitTime = 1;
        timer2.Connect("timeout", this, "on_timeout2");
        timer2.Start();
    }
    public static void on_timeout()
    {
        shoot = true;
    }
    public static void on_timeout2()
    {
        kac = false;
    }

    public override void _Process(float delta)
   {
        move = Position;

        Timer timer2 = this.GetNode<Timer>("Timer");

        var judas = GetNode<Judas>("../Judas");

        if (Math.Abs(judas.Position.x - Position.x) <= 350 && Math.Abs(judas.Position.y - Position.y) <= 350 )
        {
            kac = false;

            float speed = 200;
            float moveAmount = delta * speed;
            Vector2 MoveDirection = new Vector2(Position.x-judas.Position.x, Position.y-judas.Position.y);
            MoveDirection = MoveDirection.Normalized() * speed;
            MoveDirection = MoveAndSlide(MoveDirection);
        }
        if (kac)
        {
            float speed = 9000;
            float moveAmount = delta * speed;
            Vector2 moveDirection = (judas.Position - Position).Normalized();
            move = moveDirection * moveAmount * -1;
        }

        if (judas.health > 0 && shoot)
        {
            Cowardbullet = (PackedScene)GD.Load("res://Scenes/Cowardbullet.tscn");
            Node2D bulot = (Node2D)Cowardbullet.Instance();
            bulot.Rotation = Rotation;
            bulot.Position = Position;
            GetParent().AddChild(bulot);
            shoot = false;
        }
        LookAt(judas.Position);

        if (health3 <= 0)
        {
            QueueFree();
        }
    }
}
