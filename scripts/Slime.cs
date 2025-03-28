using Godot;
using System;

public partial class Slime : Node2D
{
    private const float SPEED = 30;
    private float direction = 1;
    private AnimatedSprite2D _sprite;
    private RayCast2D _rayCastLeft;
    private RayCast2D _rayCastRight;

    public override void _Ready()
    {
        _sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        _rayCastLeft = GetNode<RayCast2D>("RayCastLeft");
        _rayCastRight = GetNode<RayCast2D>("RayCastRight");
    }

    public override void _Process(double delta)
    {
        if (_rayCastLeft.IsColliding())
        {
            direction = 1;
            _sprite.FlipH = false;
        } else if (_rayCastRight.IsColliding())
        {
            direction = -1;
            _sprite.FlipH = true;
        }
        MoveLocalX((float)(direction * SPEED * delta));
    }
}
