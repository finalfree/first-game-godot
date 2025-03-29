using Godot;

public partial class Coin : Area2D
{
	GameManager _gameManager;
	public override void _Ready()
	{
		_gameManager = GetNode<GameManager>("%GameManager");
	}

	void OnBodyEntered(Node2D body)
	{
		GD.Print("OnBodyEntered:" + Name);
		_gameManager.AddScore();
		QueueFree();
	}
}
