using Godot;
using System;

public class Doge : KinematicBody2D
{

    public static new Vector2 moveDirection;

    public static float dashspeed = 500;

    public static Vector2 sex;

    public bool a = true;

    public float health1 = 3;


    public float Health
    {
        get
        {
            return health1;
        }
        set
        {
            health1 = value;
        }
    }
    public override void _Ready()
    {
        var area = GetNode<Area2D>("Area2D");
        area.Connect("area_entered", this, nameof(Oncollision));
    }


    private void Oncollision(Area2D with)
    {
        if (with.GetParent() is Judas judas && a)
        {
            var player = GetNode<Judas>("../Judas");
            player.Health -= 10;
            a = false;
        }
    }

    public override void _Process(float delta)
    {
        var judas = GetNode<Judas>("../Judas");

        sex = judas.Position;

        if (judas.Position.x - Position.x <= 250 && judas.Position.y - Position.y <= 250)
        {
            sex = sex.Normalized() * dashspeed;
            sex = MoveAndSlide(sex);

        }
        if (judas.Position.x - Position.x <= 20 && judas.Position.y - Position.y <= 20)
        {
            QueueFree();
        }
        else
        {
            float speed = 150;
            float moveAmount = delta * speed;
            Vector2 moveDirection = (judas.Position - Position).Normalized();
            Position += moveDirection * moveAmount;
        }

        if (health1 <= 0)
        {
            QueueFree();
        }
    }
}
