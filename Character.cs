using Godot;
using System;

/// <summary>
/// Character 类
/// </summary>
public partial class Character : CharacterBody3D
{
    /// <summary>
    /// 角色移动速度
    /// </summary>
    [Export]
	public float Speed = 5.0f;

    /// <summary>
    /// 指定移动方向。
    /// 要求摄像机与角色在同一坐标系下。
    /// 仅改变 XZ 轴的 Velocity 。
    /// </summary>
    /// <param name="uiLRUD">UI 操作的左右上下方向</param>
    /// <param name="cameraRotationOnY">摄像机在 Y 轴上的旋转角度</param>
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
        // MoveAndSlide() 会自动根据 Velocity 移动角色
		MoveAndSlide();
	}
}
