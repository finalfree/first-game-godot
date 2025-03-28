using Godot;

public partial class Coin : Area2D
{
	void OnBodyEntered(Node2D body)
	{
		GD.Print("OnBodyEntered:" + Name);
		QueueFree();
	}
}
