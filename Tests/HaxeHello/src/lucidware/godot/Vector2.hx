package lucidware.godot;

import lucidware.core.*;

@:native("godot.Vector2")
extern class Vector2Native {
    @:native("__new")
    public static function createInstanceWithXYAxis(x : Float, y : Float) : Dynamic;
}

class Vector2  extends InstanceObject {
    @:op([]) public function arrayRead(n:Dynamic) {
        if (n == 0) return x;
        if (n == 1) return y;
        if (n == 2) return z;
        if (n == "x") return x;
        if (n == "y") return y;
        if (n == "z") return z;
        throw "Invalid index";
    }

    public var x(get, set):Float;

    function get_x() {
        var untypedX = untyped this.instance.x;
        return untypedX;
    }

    function set_x(value:Float) {
        untyped this.instance.x = value;
        return value; // Missing semicolon added here
    }

    public var y(get, set):Float;

    function get_y() {
        var untypedY = untyped this.instance.y;
        return untypedY;
    }

    function set_y(value:Float) {
        untyped this.instance.y = value;
        return value;
    }

    public function new(x : Float = 0, y : Float = 0) {
        this.instance = Vector2Native.createInstanceWithXYAxis(x, y);
    }

    public static function fromInstance(instance : Dynamic) {
        var vector2 = new Vector2();
        vector2.instance = instance;
        return vector2;
    }


}