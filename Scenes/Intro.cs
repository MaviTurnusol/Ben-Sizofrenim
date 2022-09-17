using Godot;
using System;

public class Intro : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    Label Mabel;
    bool labeliyidir = true;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Mabel = GetNode<Label>("Label");
        Mabel.Text = "ben sinan ugur cocuk severim (ayak) severim";

        Timer timer = this.GetNode<Timer>("Timer");
        timer.WaitTime = 3;
        timer.Connect("timeout", this, "on_timeout");
        timer.Start();
    }

    public void on_timeout()
    {
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        
    }
}
