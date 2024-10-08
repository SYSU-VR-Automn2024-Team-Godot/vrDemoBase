using Godot;
using System;

public partial class CharaInputControl : Node
{
    public Character chara { get => GetNode<Character>("Character"); }
    public Camera3D camera { get => GetNode<Camera3D>("CameraGroup/Camera3DControledByPhantom"); }
    public GodotObject followLookAtPhantom { get => GetNode<GodotObject>("CameraGroup/FollowLookAtPhantom"); }

    /// <summary>
    /// 根据输入控制角色移动方向。
    /// 根据输入控制镜头旋转。
    /// </summary>
    public override void _PhysicsProcess(double delta) {
        // Character 运动控制
        Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        chara.MoveDirection(direction, camera.Rotation.Y);
        // chara.Velocity 已在 CharaBasePositionControl 中处理

        // Camera 旋转控制
        float rotation = Input.GetAxis("view_left", "view_right");
        RotateCamera(rotation, delta);
    }

    // ------- Camera Rotation Control -------
    /// <summary>
    /// 镜头旋转速度
    /// </summary>
    [Export]
    public float cameraRotationSpeed = 2f;
    /// <summary>
    /// 即时旋转镜头。
    /// </summary>
    /// <param name="rotation">旋转方向与力度</param>
    /// <param name="delta">即时旋转的时间间隔</param>
    private void RotateCamera(float rotation, double delta) {
        Vector3 followOffset = (Vector3)followLookAtPhantom.Call("get_follow_offset");
        followOffset = followOffset.Rotated(Vector3.Up, (float)delta * -rotation * cameraRotationSpeed);
        followLookAtPhantom.Call("set_follow_offset", followOffset);
    }
}
