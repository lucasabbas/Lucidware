package lucidware.godot;

import haxe.macro.Type.Ref;
import lucidware.core.*;
import lucidware.godot.*;

@:native("godot.Vector3")
extern class Vector3Native extends NativeObject {
    public var x : Float;
    public var y : Float;
    public var z : Float;

    @:native("zero")
    public static var ZERO : Vector3Native;

    @:native("one")
    public static var ONE : Vector3Native;

    @:native("inf")
    public static var INF : Vector3Native;

    @:native("up")
    public static var UP : Vector3Native;

    @:native("down")
    public static var DOWN : Vector3Native;

    @:native("left")
    public static var LEFT : Vector3Native;

    @:native("right")
    public static var RIGHT : Vector3Native;

    @:native("forward")
    public static var FORWARD : Vector3Native;

    @:native("back")
    public static var BACK : Vector3Native;

    @:native("modelLeft")
    public static var MODEL_LEFT : Vector3Native;

    @:native("modelRight")
    public static var MODEL_RIGHT : Vector3Native;

    @:native("modelTop")
    public static var MODEL_TOP : Vector3Native;

    @:native("modelBottom")
    public static var MODEL_BOTTOM : Vector3Native;

    @:native("modelFront")
    public static var MODEL_FRONT : Vector3Native ;

    @:native("modelRear")
    public static var MODEL_REAR : Vector3Native;

    @:native("__new")
    public function new(x : Float = 0, y : Float = 0, z : Float = 0);

    public function abs() : Vector3Native;

    public function angleTo(to : Vector3) : Vector3Native;

    public function bounce(n : Vector3) : Vector3Native;

    public function ceil() : Vector3Native;

    public function clamp(min : Vector3Native, max : Vector3Native) : Vector3Native;

    @:native("clamp")
    public function clampf(min : Float, max : Float) : Vector3Native;

    public function cross(b : Vector3Native) : Vector3Native;

    public function cubicInterpolate(b : Vector3Native, preA : Vector3Native, postB : Vector3Native, weight : Float) : Vector3Native;

    public function cubicInterpolateInTime(b : Vector3Native, preA : Vector3Native, postB : Vector3Native, weight : Float, t : Float, preAT : Float, postBT : Float) : Vector3Native;

    public function bezierInterpolate(control1 : Vector3Native, control2 : Vector3Native, end : Vector3Native, t : Float) : Vector3Native;

    public function bezierDerivative(control1 : Vector3Native, control2 : Vector3Native, end : Vector3Native, t : Float) : Vector3Native;

    public function directionTo(to : Vector3Native) : Vector3Native;

    public function distanceTo(to : Vector3Native) : Float;

    public function distanceSquaredTo(to : Vector3Native) : Float;

    public function dot(with : Vector3Native) : Float;

    public function floor() : Vector3Native;

    public function inverse() : Vector3Native;

    public function isFinite() : Bool;

    public function isNormalized() : Bool;

    public function length() : Float;

    public function lengthSquared() : Float;

    public function lerp(to : Vector3Native, weight : Float) : Vector3Native;

    public function limitLength(length : Float = 1) : Vector3Native;

    public function max(with : Vector3Native) : Vector3Native;

    @:native("max")
    public function maxf(with : Float) : Vector3Native;

    public function min(with : Vector3Native) : Vector3Native;

    @:native("min")
    public function minf(with : Float) : Vector3Native;

    public function maxAxisIndex() : Int;

    public function minAxisIndex() : Int;

    public function moveToward(to : Vector3Native, delta : Float) : Vector3Native;

    public function normalized() : Vector3Native;

    public function outer(with : Vector3Native) : Dynamic;

    public function posModf(mod : Float) : Vector3Native;

    public function posMod(modv : Vector3Native) : Vector3Native;

    public function project(onNormal : Vector3Native) : Vector3Native;

    public function reflect(normal : Vector3Native) : Vector3Native;

    public function rotated(axis : Vector3Native, angle : Float) : Vector3Native;

    public function round() : Vector3Native;

    public function sign() : Vector3Native;

    public function signedAngleTo(to : Vector3Native, axis : Vector3Native) : Float;

    public function slerp(to : Vector3, weight : Float) : Vector3Native;

    public function slide(normal : Vector3Native) : Vector3Native;

    public function snapped(step : Vector3Native) : Vector3Native;

    @:native("snapped")
    public function snappedf(step : Float) : Vector3Native;

    public function equals(other : Vector3Native) : Bool;

    public function isEqualApprox(other : Vector3Native) : Bool;

    public function isZeroApprox() : Bool;

    public function __add(rhs : Dynamic) : Vector3Native;

    public function __sub(rhs : Dynamic) : Vector3Native;

    public function __mul(rhs : Dynamic) : Vector3Native;

    public function __div(rhs : Dynamic) : Vector3Native;

    public function __mod(rhs : Dynamic) : Vector3Native;

    public function __eq(rhs : Vector3) : Bool;

    public function __ne(rhs : Vector3) : Bool;

    public function __lt(rhs : Vector3) : Bool;

    public function __le(rhs : Vector3) : Bool;

    public function __gt(rhs : Vector3) : Bool;

    public function __ge(rhs : Vector3) : Bool;
}

abstract Vector3(Vector3Native) from Vector3Native {
    public function new(x : Float = 0, y : Float = 0, z : Float = 0) {
        this = new Vector3Native(x, y, z);
    }

    @:op(a.b) public function fieldRead(name:String)
        {
            if (name == "toString") {
                return function() : String {
                    var v = this;
                    return untyped __lua__("v.toString()");
                }
            } else if (Reflect.hasField(this, name)) {
                return Reflect.field(this, name);
            } else {
                throw "Invalid field";
            }
        }

    @:op(a.b()) 
        
        @:op(a.b) public function fieldWrite(name:String, value:String){
            if (Reflect.hasField(this, name)) {
                Reflect.setField(this, name, value);
            } else {
                throw "Invalid field";
            }
        }
    
        @:op([]) public function arrayRead(n:Dynamic) {
            if (n == 0) return this.x;
            if (n == 1) return this.y;
            if (n == 2) return this.z;
            if (n == "x") return this.x;
            if (n == "y") return this.y;
            if (n == "z") return this.z; 
            throw "Invalid index";
        }
        
        @:op([]) public function arrayWrite(n:Dynamic, value:Float) {
            if (n == 0) this.x = value;
            else if (n == 1) this.y = value;
            else if (n == 2) this.z = value;
            else if (n == "x") this.x = value;
            else if (n == "y") this.y = value;
            else if (n == "z") this.z = value;
            else throw "Invalid index";
        }
    
        @:op(A + B)
        public function add(rhs: Any) : Vector3 {
            var lhs = this;
            return untyped __lua__("lhs + rhs");
        }
    
        @:op(A - B)
        public function sub(rhs: Any) : Vector3 {
            var lhs = this;
            return untyped __lua__("lhs - rhs");
        }
    
        @:op(A * B)
        public function mul(rhs: Any) : Vector3 {
            var lhs = this;
            return untyped __lua__("lhs * rhs");
        }
    
        @:op(A / B)
        public function div(rhs: Any) : Vector3 {
            var lhs = this;
            return untyped __lua__("lhs / rhs");
        }
    
        @:op(A % B)
        public function mod(rhs: Any) : Vector3 {
            var lhs = this;
            return untyped __lua__("lhs % rhs");
        }
    
        @:op(A == B)
        public function eq(rhs: Vector3Native) : Bool {
            var lhs = this;
            return untyped __lua__("lhs == rhs");
        }
    
        @:op(A != B)
        public function neq(rhs: Vector3Native) : Bool {
            var lhs = this;
            return untyped __lua__("lhs ~= rhs");
        }
    
        @:op(A < B)
        public function lt(rhs: Vector3Native) : Bool {
            var lhs = this;
            return untyped __lua__("lhs < rhs");
        }
    
        @:op(A <= B)
        public function lte(rhs: Vector3Native) : Bool {
            var lhs = this;
            return untyped __lua__("lhs <= rhs");
        }
    
        @:op(A > B)
        public function gt(rhs: Vector3Native) : Bool {
            var lhs = this;
            return untyped __lua__("lhs > rhs");
        }
    
        @:op(A >= B)
        public function gte(rhs: Vector3Native) : Bool {
            var lhs = this;
            return untyped __lua__("lhs >= rhs");
        }

    public static function toString(v:Vector3Native) {
        return untyped __lua__("v.toString()");
    }
}