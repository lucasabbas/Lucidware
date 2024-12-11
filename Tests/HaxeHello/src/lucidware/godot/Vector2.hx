package lucidware.godot;

import lucidware.core.*;

@:native("godot.Vector2")
extern class Vector2Native {
    @:native("__new")
    public static function createInstanceWithXYAxis(x : Float, y : Float) : Dynamic;
}

class Vector2  extends InstanceObject {
    @:op([]) public function arrayRead(n:Int) {
        if (n == 0) return x;
        if (n == 1) return y;
        throw "Invalid index";
    }

    @:op([]) public function arrayRead(n:String) {
        if (n == "x") return x;
        if (n == "y") return y;
        throw "Invalid index";
    }
    
    public var x(get, set):Float;

    function get_x() {
        var untypedX = untyped this.instance.x;
        return cast untypedX Float;
    }

    function set_x(value:Float) {
        untyped this.instance.x = value;
        return value;
    }

    public var y(get, set):Float;

    function get_y() {
        var untypedY = untyped this.instance.y;
        return cast untypedY Float;
    }

    function set_y(value:Float) {
        untyped this.instance.y = value;
        return value;
    }

    public function new() {
        this.instance = Vector2Native.createInstance();
    }

    public function new(x : Float, y : Float) {
        this.instance = Vector2Native.createInstanceWithXYAxis(x, y);
    }


}