using Godot;
using System;

public partial class Character : CharacterBody3D
{
    [Export]
	public float Speed = 5.0f;

    public void MoveDirection(Vector2 uiLRUD, float cameraRotationOnY) {
        Vector3 direction = (Transform.Basis * new Vector3(uiLRUD.X, 0, uiLRUD.Y)); // maybe this is wrong
        if (direction != Vector3.Zero)
        {
            direction = direction.Rotated(Vector3.Up, cameraRotationOnY); // maybe this is wrong
            direction = direction.Normalized() * Speed;
            direction.Y = Velocity.Y;
            Velocity = direction;
        } else {
            Velocity = new Vector3(0, Velocity.Y, 0);
        }
    }

	public override void _Process(double delta)
	{
		MoveAndSlide();
	}
}
