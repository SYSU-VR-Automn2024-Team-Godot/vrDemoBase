
## 现有问题
角色出现重影

不是这个抖动
https://docs.godotengine.org/zh-cn/4.x/tutorials/rendering/jitter_stutter.html

而是幻影相机的问题
https://phantom-camera.dev/support/faq#i-m-seeing-jitter-what-can-i-do

我自己尝试的一种解决方案是在 Process 而非 PhysicsProcess 中更新角色的位置，这样角色的位置更新会更加平滑。但是这样做会导致角色的位置更新频率和物理引擎的更新频率不一致，可能会导致一些问题。
