package lucidware.godot;

import lucidware.core.*;

@:native("godot.Vector3")
extern class Vector3Native extends NativeObject {
    @:native("__new")
    public static function createInsanceWithXYZArgs(x : Float, y : Float, z : Float) : Dynamic;
}

class Vector3 extends InstanceObject {
    public enum Axis {
        X,
        Y,
        Z
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

    public var z(get, set):Float;

    function get_z() {
        var untypedZ = untyped this.instance.z;
        return cast untypedZ Float;
    }

    function set_z(value:Float) {
        untyped this.instance.z = value;
        return value;
    }
    
    public function new() {
        this.instance = Vector3Native.createInstance();
    }

    public function new(x : Float, y : Float, z : Float) {
        this.instance = Vector3Native.createInsanceWithXYZArgs(
                x, y, z
        );
    }

    public function new(instance : Dynamic) {
        this.instance = instance;
    }

    public static var ZERO : Vector3 = new Vector3(0, 0, 0);

    public static var ONE : Vector3 = new Vector3(1, 1, 1);

    public static var INF : Vector3 = new Vector3(Infinity, Infinity, Infinity);

    public static var UP : Vector3 = new Vector3(0, 1, 0);

    public static var DOWN : Vector3 = new Vector3(0, -1, 0);

    public static var LEFT : Vector3 = new Vector3(-1, 0, 0);

    public static var RIGHT : Vector3 = new Vector3(1, 0, 0);

    public static var FORWARD : Vector3 = new Vector3(0, 0, -1);

    public static var BACK : Vector3 = new Vector3(0, 0, 1);

    public static var MODEL_LEFT : Vector3 = new Vector3(1, 0, 0);

    public static var MODEL_RIGHT : Vector3 = new Vector3(-1, 0, 0);

    public static var MODEL_TOP : Vector3 = new Vector3(0, 1, 0);

    public static var MODEL_BOTTOM : Vector3 = new Vector3(0, -1, 0);

    public static var MODEL_FRONT : Vector3 = new Vector3(0, 0, 1);

    public static var MODEL_REAR : Vector3 = new Vector3(0, 0, -1);
    
    public function abs() : Vector3 {
        return untyped this.instance.abs();
    }

    public function angleTo(to : Vector3) : Float {
        return untyped this.instance.angleTo(to.instance);
    }

    public function bounce(n : Vector3) : Vector3 {
        return untyped this.instance.bounce(n.instance);
    }

    public function ceil() : Vector3 {
        return untyped this.instance.ceil();
    }

    public function clamp(min : Vector3, max : Vector3) : Vector3 {
        return untyped this.instance.clamp(min.instance, max.instance);
    }

    public function clamp(min : Float, max : Float) : Vector3 {
        return untyped this.instance.clamp(min, max);
    }

    public function cross(b : Vector3) : Vector3 {
        return untyped this.instance.cross(b.instance);
    }

    public function cubicInterpolate(b : Vector3, preA : Vector3, postB : Vector3, weight : Float) : Vector3 {
        return untyped this.instance.cubicInterpolate(b.instance, preA.instance, postB.instance, weight);
    }

    public function cubicInterpolateInTime(b : Vector3, preA : Vector3, postB : Vector3, weight : Float, t : Float, preAT : Float, postBT : Float) {
        return untyped this.instance.cubicInterpolateInTime(b.instance, preA.instance, postB.instance, weight, t, preAT, postBT);        
    }

    public function bezierInterpolate(control1 : Vector3, control2 : Vector3, end : Vector3, t : Float) : Vector3 {
        return untyped this.instance.bezierInterpolate(control1.instance, control2.instance, end.instance, t);
    }

    public function bezierDerivative(control1 : Vector3, control2 : Vector3, end : Vector3, t : Float) : Vector3 {
        return untyped this.instance.bezierDerivative(control1.instance, control2.instance, end.instance, t);
    }

    public function directionTo(to : Vector3) : Vector3 {
        return untyped this.instance.directionTo(to.instance);
    }

    public function distanceTo(to : Vector3) : Float {
        return untyped this.instance.distanceTo(to.instance);
    }

    public function distanceSquaredTo(to : Vector3) : Float {
        return untyped this.instance.distanceSquaredTo(to.instance);
    }

    public function dot(with : Vector3) : Float {
        return untyped this.instance.dot(with.instance);
    }

    public function floor() : Vector3 {
        return untyped this.instance.floor();
    }

    public function inverse() : Vector3 {
        return untyped this.instance.inverse();
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

    public function lengthSquared() : Float {
        return untyped this.instance.lengthSquared();
    }

    public function lerp(to : Vector3, weight : Float) : Vector3 {
        return untyped this.instance.lerp(to.instance, weight);
    }

    public function limitLength(length : Float = 1) : Vector3 {
        return untyped this.instance.limitLength(length);   
    }

    public function max(with : Vector3) : Vector3 {
        return untyped this.instance.max(with.instance);
    }

    public function max(with : Float) : Vector3 {
        return untyped this.instance.max(with);
    }

    public function min(with : Vector3) : Vector3 {
        return untyped this.instance.min(with.instance);
    }

    public function min(with : Float) : Vector3 {
        return untyped this.instance.min(with);
    }

    public function maxAxisIndex() : Vector3.Axis {
        var val = untyped this.instance.maxAxisIndex();
        return cast val Vector3.Axis;
    }

    public function minAxisIndex() : Vector3.Axis {
        var val = untyped this.instance.minAxisIndex();
        return cast val Vector3.Axis;
    }

    public function moveToward(to : Vector3, delta : Float) : Vector3 {
        return untyped this.instance.moveToward(to.instance, delta);
    }

    public function normalized() : Vector3 {
        return untyped this.instance.normalized();
    }

    public function outer(with : Vector3) : Dynamic {
        return untyped this.instance.outer(with.instance);
    }

    public function posMod(mod : Float) : Vector3 {
        return untyped this.instance.posMod(mod);
    }

    public function posMod(modv : Vector3) : Vector3 {
        return untyped this.instance.posMod(modv.instance);
    }

    public function project(onNormal : Vector3) : Vector3 {
        return untyped this.instance.project(onNormal.instance);
    }

    public function reflect(normal : Vector3) : Vector3 {
        return untyped this.instance.reflect(normal.instance);
    }

    public function rotated(axis : Vector3, angle : Float) : Vector3 {
        return untyped this.instance.rotated(axis.instance, angle);
    }

    public function round() : Vector3 {
        return untyped this.instance.round();
    }

    public function sign() : Vector3 {
        return untyped this.instance.sign();
    }

    public function signedAngleTo(to : Vector3, axis : Vector3) : Float {
        return untyped this.instance.signedAngleTo(to.instance, axis.instance);
    }

    public function slerp(to : Vector3, weight : Float) : Vector3 {
        return untyped this.instance.slerp(to.instance, weight);
    }

    public function slide(normal : Vector3) : Vector3 {
        return untyped this.instance.slide(normal.instance);
    }

    public function snapped(step : Vector3) : Vector3 {
        return untyped this.instance.snapped(step.instance);
    }

    public function snapped(step : Float) : Vector3 {
        return untyped this.instance.snapped(step);
    }
    
    @:op(a + b)
    public function add(rhs: Vector3) : Vector3 {
        return untyped this.instance + rhs.instance;
    }

    @:op(a - b)
    public function sub(rhs: Vector3) : Vector3 {
        return untyped this.instance - rhs.instance;
    }

    @:op(a * b)
    public function mul(rhs: Vector3) : Vector3 {
        return untyped this.instance * rhs.instance;
    }

    @:op(a * b)
    public function mul(rhs: Float) : Vector3 {
        return untyped this.instance * rhs;
    }

    @:op(a / b)
    public function div(rhs: Vector3) : Vector3 {
        return untyped this.instance / rhs.instance;
    }

    @:op(a / b)
    public function div(rhs: Float) : Vector3 {
        return untyped this.instance / rhs;
    }

    @:op(a % b)
    public function mod(rhs: Vector3) : Vector3 {
        return untyped this.instance % rhs.instance;
    }

    @:op(a % b)
    public function mod(rhs: Float) : Vector3 {
        return untyped this.instance % rhs;
    }

    @:op(a == b)
    public function eq(rhs: Vector3) : Bool {
        return untyped this.instance == rhs.instance;
    }

    @:op(a != b)
    public function neq(rhs: Vector3) : Bool {
        return untyped this.instance != rhs.instance;
    }

    @:op(a < b)
    public function lt(rhs: Vector3) : Bool {
        return untyped this.instance < rhs.instance;
    }

    @:op(a <= b)
    public function lte(rhs: Vector3) : Bool {
        return untyped this.instance <= rhs.instance;
    }

    @:op(a > b)
    public function gt(rhs: Vector3) : Bool {
        return untyped this.instance > rhs.instance;
    }

    @:op(a >= b)
    public function gte(rhs: Vector3) : Bool {
        return untyped this.instance >= rhs.instance;
    }

    public function equals(other : Vector3) : Bool {
        return untyped this.instance.equals(other.instance);
    }

    public function isEqualApprox(other : Vector3) : Bool {
        return untyped this.instance.isEqualApprox(other.instance);
    }

    public function isZeroApprox() : Bool {
        return untyped this.instance.isZeroApprox();
    }

    public function toString() : String {
        return untyped this.instance.toString();
    }
}