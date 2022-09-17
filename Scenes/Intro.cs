using Godot;
using System;

public class Intro : Node2D
{

    public override void _Ready()
    {
        Timer timer = this.GetNode<Timer>("Timer");
        timer.WaitTime = (float)2;
        timer.Connect("timeout", this, "on_timeout");
        timer.Start();

        Timer timer2 = this.GetNode<Timer>("Timer2");
        timer2.WaitTime = (float)2;
        timer2.Connect("timeout", this, "on_timeout2");

        Timer timer3 = this.GetNode<Timer>("Timer3");
        timer3.WaitTime = (float)2;
        timer3.Connect("timeout", this, "on_timeout3");
    }

    public void on_timeout()
    {
        Timer timer = this.GetNode<Timer>("Timer");
        Timer timer2 = this.GetNode<Timer>("Timer2");
        var label = GetNode<Label>("Label");
        label.Text = ("I am a good person");
        timer.Stop();
        timer2.Start();
    }

    public void on_timeout2()   
    {
        Timer timer3 = this.GetNode<Timer>("Timer3");
        Timer timer2 = this.GetNode<Timer>("Timer2");
        var label = GetNode<Label>("Label");
        label.Text = ("therefore i have to destroy the evil...");
        timer2.Stop();
        timer3.Start();
    }
    public void on_timeout3()
    {
        GetTree().ChangeScene("res://Scenes/World.tscn");
    }
    // eyoo
}
