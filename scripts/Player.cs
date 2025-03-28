using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 150.0f;
	public const float JumpVelocity = -300.0f;
	
	private AnimatedSprite2D _sprite;

	public override void _Ready()
	{
		_sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		var isOnFloor = IsOnFloor();
		if (!isOnFloor)
		{
			_sprite.Play("jump");
			velocity += GetGravity() * (float)delta;
		}
		
		// Handle Jump.
		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		var direction = Input.GetAxis("move_left", "move_right");
		if (direction != 0)
		{
			if (direction > 0)
			{
				_sprite.FlipH = false;
			}
			else
			{
				_sprite.FlipH = true;
			}

			if (isOnFloor)
			{
				_sprite.Play("run");
			}
			velocity.X = direction * Speed;
		}
		else
		{
			if (isOnFloor)
			{
				_sprite.Play("idle");
			}
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
