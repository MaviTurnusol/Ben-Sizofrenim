using Godot;
using System;

public class Judas : KinematicBody2D
{
    PackedScene Bulletscene;

    [Export] public int speed = 200;

    public Vector2 velocity = new Vector2();

    public static bool shoot;

    public float health = 20;

    public static Vector2 mousepos;

    public static Vector2 yer;
    
    static Sprite amseverim;

    static Vector2 vRight;
    static Vector2 vLeft;
    static Vector2 vUp;
    static Vector2 vDown;
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }

    public void GetInput()
    {
        velocity = new Vector2();

        if (Input.IsKeyPressed((int)KeyList.D))
            velocity.x += 1;
            LookAt(vRight);

        if (Input.IsKeyPressed((int)KeyList.A))
            velocity.x -= 1;
            LookAt(vLeft);

        if (Input.IsKeyPressed((int)KeyList.S))
            velocity.y += 1;

        if (Input.IsKeyPressed((int)KeyList.W))
            velocity.y -= 1;

        velocity = velocity.Normalized() * speed;


    }

    public override void _PhysicsProcess(float delta)
    {
        GetInput();
        velocity = MoveAndSlide(velocity);

        if (health <= 0)
        {
            QueueFree();
        }
        
        vRight = new Vector2(Position.x+10, Position.y);
        vLeft = new Vector2(Position.x-10, Position.y);
        vUp = new Vector2(Position.x, Position.y-10);
        vDown = new Vector2(Position.x, Position.y+10);

    }

    public override void _Ready()
    {
        Bulletscene = GD.Load<PackedScene>("res://Scenes/Bullet.tscn");

        Timer timer = this.GetNode<Timer>("Timer");
        timer.WaitTime = (float) 1;
        timer.Connect("timeout", this, "on_timeout");
        timer.Start();

        amseverim = GetChild<Sprite>(0);
    }

    public static void on_timeout()
    {
        shoot = true;
    }

 

    public override void _UnhandledInput(InputEvent @event)
    {
        base._UnhandledInput(@event);

        if (@event is InputEventMouseButton mouseButton)
        {
            if (shoot && mouseButton.ButtonIndex == (int)ButtonList.Left && mouseButton.Pressed)
            {
                Bullet bullet = (Bullet)Bulletscene.Instance();
                bullet.Position = Position;
                bullet.Rotation = Rotation;
                //GetParent().AddChild(bullet);
                GetTree().SetInputAsHandled();
                shoot = false;
            }
        }

    }
}
