## 统一环境

使用的 Godot 版本为 [Download Godot 4.3 (stable) – Godot Engine](https://godotengine.org/download/archive/4.3-stable/) ，且统一使用 .NET 版本进行 C# 开发。
此版本对应代码仓为 [Release 4.3-stable · godotengine/godot (github.com)](https://github.com/godotengine/godot/releases/tag/4.3-stable) 。

## 实现功能
[x] 角色平移（相对于镜头方向）
[x] 镜头跟随、转动
[ ] 地面物理效果及重力效果

## 现有问题

### 1. 角色平移时的抖动
角色出现重影

不是这个抖动
https://docs.godotengine.org/zh-cn/4.x/tutorials/rendering/jitter_stutter.html

而是幻影相机的问题
https://phantom-camera.dev/support/faq#i-m-seeing-jitter-what-can-i-do

我自己尝试的一种解决方案是在 Process 而非 PhysicsProcess 中更新角色的位置，这样角色的位置更新会更加平滑。但是这样做会导致角色的位置更新频率和物理引擎的更新频率不一致，可能会导致一些问题。
