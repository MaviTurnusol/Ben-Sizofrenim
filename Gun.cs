using Godot;
using System;

public class Gun : Node2D
{
    PackedScene Bulletscene;
    static Vector2 pluer;
    static Vector2 mousepos;
    static Vector2 despos;
    static int dessc;
    Sprite pistol;
    public static bool shoot;
    public override void _Ready()
    {
        pistol = GetChild<Sprite>(0);

        Bulletscene = GD.Load<PackedScene>("res://Scenes/Bullet.tscn");

        Timer timer = this.GetNode<Timer>("Timer");
        timer.WaitTime = (float) 1;
        timer.Connect("timeout", this, "on_timeout");
        timer.Start();
    }

   public override void _Process(float delta)
    {
        pluer = GetTree().Root.GetNode("World").GetNode<KinematicBody2D>("Judas").Position;
        mousepos = GetGlobalMousePosition();

        if(pluer.x - mousepos.x < 0)
        {
            despos.x = pluer.x + 50;
            dessc = -1;
            pistol.FlipV = false;
        } else {
            despos.x = pluer.x - 50;
            pistol.FlipV = true;
        }

        despos.y = pluer.y + 10;
        LookAt(mousepos);

        Position = despos;
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
                bullet.Position = new Vector2(Position.x, Position.y-15);
                bullet.Rotation = Rotation;
                GetParent().AddChild(bullet);
                GetTree().SetInputAsHandled();
                shoot = false;
            }
        }

    }
}
