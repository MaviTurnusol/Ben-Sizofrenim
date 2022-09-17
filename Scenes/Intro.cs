using Godot;
using System;

public class Intro : Node2D
{

    public override void _Ready()
    {
        var label = GetNode<Label>("Label");
        label.Text = ("Ben");
    }


}
