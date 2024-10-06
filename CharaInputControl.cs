using Godot;
using System;

public partial class CharaInputControl : Node
{
    public CharaInputControl() {
    }

    public Character chara { get => GetNode<Character>("Character"); }
    public Camera3D camera { get => GetNode<Camera3D>("CameraGroup/Camera3DControledByPhantom"); }
    public GodotObject followLookAtPhantom { get => GetNode<GodotObject>("CameraGroup/FollowLookAtPhantom"); }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public override void _PhysicsProcess(double delta) {
        Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        chara.MoveDirection(direction, camera.Rotation.Y);
        // chara.Velocity 已在 CharaBasePositionControl 中处理
        float rotation = Input.GetAxis("view_left", "view_right");
        RotateCamera(rotation, delta);
    }

    // Camera Rotation Control
    [Export]
    public float cameraRotationSpeed = 2f;
    private void RotateCamera(float rotation, double delta) {
        Vector3 followOffset = (Vector3)followLookAtPhantom.Call("get_follow_offset");
        followOffset = followOffset.Rotated(Vector3.Up, (float)delta * -rotation * cameraRotationSpeed);
        followLookAtPhantom.Call("set_follow_offset", followOffset);
    }
}
