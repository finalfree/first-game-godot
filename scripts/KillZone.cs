using Godot;
using System;

public partial class KillZone : Area2D
{
    void OnBodyEntered(Node2D body)
    {
        GD.Print("OnBodyEntered:" + Name);
        GetNode<Timer>("Timer").Start();
    }

    void DeathAfterOneSecond()
    {
        GD.Print("Reload Game Now");
        GetTree().ReloadCurrentScene();
    }
}
