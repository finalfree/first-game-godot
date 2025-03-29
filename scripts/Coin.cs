using Godot;

public partial class Coin : Area2D
{
	GameManager _gameManager;
	AnimationPlayer _animationPlayer;
	public override void _Ready()
	{
		_gameManager = GetNode<GameManager>("%GameManager");
		_animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	void OnBodyEntered(Node2D body)
	{
		GD.Print("OnBodyEntered:" + Name);
		_gameManager.AddScore();
		_animationPlayer.Play("collect");
	}
}
