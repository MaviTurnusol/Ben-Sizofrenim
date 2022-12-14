using Godot;
using System;

public class Bullet : Node2D
{
    
    float speed = 1000;

    public float range = 800;

    private float distancetravelled = 0;


    public override void _Ready()
   {
        var area = GetNode<Area2D>("Area2D");
        area.Connect("area_entered", this, "Oncollision");
        area.Connect("body_entered", this, "Oncollision");
    }
    public override void _Process(float delta)
    {
        float moveAmount = speed * delta;
        Position += Transform.x.Normalized() * moveAmount;

        distancetravelled += moveAmount;
        if (distancetravelled > range)
        {
            QueueFree();
        }
    }
    public void Oncollision(Area2D with)
    {
        if (with.GetParent() is Doge doge)
        {
            doge.health1 -= 1;
            QueueFree();

        }
        if (with.GetParent() is Coward coward)
        {
            coward.health2 -= 1;
            QueueFree();
        }
        if (with.GetParent() is Isidro isidro)
        {
            isidro.health3 -= 1;
            QueueFree();
        }

    }
}
