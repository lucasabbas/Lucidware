package lucidware.godot;

import lucidware.core.*;

@:native("godot.Vector2")
extern class Vector2Native {
    @:native("__new")
    public function new(x : Float, y : Float) : Dynamic;
}

enum Vector2Axis {
    X;
    Y;
}

class Vector2  extends InstanceObject {
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
        this.instance = new Vector2Native(x, y);
    }

    public static function fromInstance(instance : Dynamic) {
        var vector2 = new Vector2();
        vector2.instance = instance;
        return vector2;
    }

    public static var ZERO : Vector2 = new Vector2(0, 0);
    public static var ONE : Vector2 = new Vector2(1, 1);
    public static var INF : Vector2T = untyped Vector2Native.inf;
    public static var UP : Vector2 = new Vector2(0, -1);
    public static var DOWN : Vector2 = new Vector2(0, 1);
    public static var LEFT : Vector2 = new Vector2(-1, 0);
    public static var RIGHT : Vector2 = new Vector2(1, 0);

    public function abs() : Vector2 {
        return Vector2.fromInstance(untyped this.instance.abs());
    }

    public function angle() : Float {
        return untyped this.instance.angle();
    }

    public function angleTo(to : Vector2) : Float {
        return untyped this.instance.angleTo(to.instance);
    }

    public function aspect() : Float {
        return untyped this.instance.aspect();
    }

    public function bounce(n : Vector2) : Vector2 {
        return Vector2.fromInstance(untyped this.instance.bounce(n.instance));
    }

    public function ceil() : Vector2 {
        return Vector2.fromInstance(untyped this.instance.ceil());
    }

    public function clamp(min : Vector2, max : Vector2) : Vector2 {
        return Vector2.fromInstance(untyped this.instance.clamp(min.instance, max.instance));
    }

    public function clampf(min : Float, max : Float) : Vector2 {
        return Vector2.fromInstance(untyped this.instance.clampf(min, max));
    }

    public function cross(to : Vector2) : Float {
        return untyped this.instance.cross(to.instance);
    }

    public function cubicInterpolate(b : Vector2, preA : Vector2, postB : Vector2, weight : Float) : Vector2 {
        return Vector2.fromInstance(untyped this.instance.cubicInterpolate(b.instance, preA.instance, postB.instance, weight));
    }

    public function cubicInterpolateInTime(b : Vector2, preA : Vector2, postB : Vector2, weight : Float, t : Float, preAT : Float, postBT : Float) : Vector2 {
        return Vector2.fromInstance(untyped this.instance.cubicInterpolateInTime(b.instance, preA.instance, postB.instance, weight, t, preAT, postBT));
    }

    public function bezierInterpolate(control1 : Vector2, control2 : Vector2, end : Vector2, t : Float) : Vector2 {
        return Vector2.fromInstance(untyped this.instance.bezierInterpolate(control1.instance, control2.instance, end.instance, t));
    }

    public function bezierDerivative(control1 : Vector2, control2 : Vector2, end : Vector2, t : Float) : Vector2 {
        return Vector2.fromInstance(untyped this.instance.bezierDerivative(control1.instance, control2.instance, end.instance, t));
    }

    public function distanceTo(to : Vector2) : Float {
        return untyped this.instance.distanceTo(to.instance);
    }

    public function distanceSquaredTo(to : Vector2) : Float {
        return untyped this.instance.distanceSquaredTo(to.instance);
    }

    public function dot(to : Vector2) : Float {
        return untyped this.instance.dot(to.instance);
    }

    public function floor() : Vector2 {
        return Vector2.fromInstance(untyped this.instance.floor());
    }

    public function inverse() : Vector2 {
        return Vector2.fromInstance(untyped this.instance.inverse());
    }

    public function isFinite() : Bool {
        return untyped this.instance.isFinite();
    }

    public function isNormalized() : Bool {
        return untyped this.instance.isNormalized();
    }

    public function length() : Float {
        return untyped this.instance.length();
    }

    public function lerp(to : Vector2, weight : Float) : Vector2 {
        return Vector2.fromInstance(untyped this.instance.lerp(to.instance, weight));
    }

    public function limitLength(length : Float = 1) : Vector2 {
        return Vector2.fromInstance(untyped this.instance.limitLength(length));
    }

    public function max(with : Vector2) : Vector2 {
        return Vector2.fromInstance(untyped this.instance.max(with.instance));
    }

    public function maxf(with : Float) : Vector2 {
        return Vector2.fromInstance(untyped this.instance.maxf(with));
    }

    public function min(with : Vector2) : Vector2 {
        return Vector2.fromInstance(untyped this.instance.min(with.instance));
    }

    public function minf(with : Float) : Vector2 {
        return Vector2.fromInstance(untyped this.instance.minf(with));
    }

    public function maxAxisIndex() : Vector2Axis {
        var axis = untyped this.instance.maxAxisIndex();
        if (axis == 0) {
            return Vector2Axis.X;
        } else {
            return Vector2Axis.Y;
        }
    }

    public function minAxisIndex() : Vector2Axis {
        var axis = untyped this.instance.minAxisIndex();
        if (axis == 0) {
            return Vector2Axis.X;
        } else {
            return Vector2Axis.Y;
        }
    }

    public function moveToward(to : Vector2, delta : Float) : Vector2 {
        return Vector2.fromInstance(untyped this.instance.moveToward(to.instance, delta));
    }

    public function normalized() : Vector2 {
        return Vector2.fromInstance(untyped this.instance.normalized());
    }

    public function posModf(mod : Float) : Vector2 {
        return Vector2.fromInstance(untyped this.instance.posModf(mod));
    }

    public function posMod(mod : Vector2) : Vector2 {
        return Vector2.fromInstance(untyped this.instance.posMod(mod.instance));
    }

    public function project(to : Vector2) : Vector2 {
        return Vector2.fromInstance(untyped this.instance.project(to.instance));
    }

    public function reflect(n : Vector2) : Vector2 {
        return Vector2.fromInstance(untyped this.instance.reflect(n.instance));
    }

    public function rotated(phi : Float) : Vector2 {
        return Vector2.fromInstance(untyped this.instance.rotated(phi));
    }

    public function round() : Vector2 {
        return Vector2.fromInstance(untyped this.instance.round());
    }

    public function sign() : Vector2 {
        return Vector2.fromInstance(untyped this.instance.sign());
    }

    public function slide(n : Vector2) : Vector2 {
        return Vector2.fromInstance(untyped this.instance.slide(n.instance));
    }

    public function snapped(step : Vector2) : Vector2 {
        return Vector2.fromInstance(untyped this.instance.snapped(step.instance));
    }

    public function snappedf(step : Float) : Vector2 {
        return Vector2.fromInstance(untyped this.instance.snapped(step));
    }

    public function orthogonal() : Vector2 {
        return Vector2.fromInstance(untyped this.instance.orthogonal());
    }

    public static function fromAngle(angle : Float) : Vector2 {
        return untyped Vector2Native.fromAngle(angle);
    }

    public function add(rhs : Any) : Vector2 {
        if (Std.isOfType(rhs, Vector2)) {
            return Vector2.fromInstance(untyped this.instance + rhs.instance);
        } else {
            return Vector2.fromInstance(untyped this.instance + rhs);
        }
    }

    public function sub(rhs : Any) : Vector2 {
        if (Std.isOfType(rhs, Vector2)) {
            return Vector2.fromInstance(untyped this.instance - rhs.instance);
        } else {
            return Vector2.fromInstance(untyped this.instance - rhs);
        }
    }

    public function mul(rhs : Any) : Vector2 {
        if (Std.isOfType(rhs, Vector2)) {
            return Vector2.fromInstance(untyped this.instance * rhs.instance);
        } else {
            return Vector2.fromInstance(untyped this.instance * rhs);
        }
    }

    public function div(rhs : Any) : Vector2 {
        if (Std.isOfType(rhs, Vector2)) {
            return Vector2.fromInstance(untyped this.instance / rhs.instance);
        } else {
            return Vector2.fromInstance(untyped this.instance / rhs);
        }
    }

    public function mod(rhs : Any) : Vector2 {
        if (Std.isOfType(rhs, Vector2)) {
            return Vector2.fromInstance(untyped this.instance % rhs.instance);
        } else {
            return Vector2.fromInstance(untyped this.instance % rhs);
        }
    }

    public function equals(rhs : Vector2) : Bool {
        return untyped this.instance == rhs.instance;
    }

    public function notEquals(rhs : Vector2) : Bool {
        return untyped this.instance != rhs.instance;
    }

    public function lessThan(rhs : Vector2) : Bool {
        return untyped this.instance < rhs.instance;
    }

    public function lessThanOrEqual(rhs : Vector2) : Bool {
        return untyped this.instance <= rhs.instance;
    }
    
    public function greaterThan(rhs : Vector2) : Bool {
        return untyped this.instance > rhs.instance;
    }

    public function greaterThanOrEqual(rhs : Vector2) : Bool {
        return untyped this.instance >= rhs.instance;
    }

    public function isZeroApprox(other : Vector2) : Bool {
        return untyped this.instance.isZeroApprox(other.instance);
    }

    public function toString() : String {
        return untyped __lua__("self.instance.toString()");
    }
}