using Godot;
using System;

public class StartButton : Button
{
    public override void _Ready()
    {

    }

    public override void _Pressed()
    {
        GetTree().ChangeScene("res://Scenes/World.tscn");
    }
}