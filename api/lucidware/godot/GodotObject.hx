package lucidware.godot;

import lucidware.core.*;

@:native("godot.Object")
extern class GodotObject extends NativeObject {
    @:native("__new")
    public function new();
}