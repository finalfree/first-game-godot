using Godot;
using System;

public partial class KillZone : Area2D
{
    void OnBodyEntered(Node2D body)
    {
        Engine.TimeScale = 0.5;
        body.GetNode<CollisionShape2D>("CollisionShape2D").QueueFree();
        GD.Print("OnBodyEntered:" + Name);
        GetNode<Timer>("Timer").Start();
    }

    void DeathAfterOneSecond()
    {
        Engine.TimeScale = 1;
        GD.Print("Reload Game Now");
        GetTree().ReloadCurrentScene();
    }
}
