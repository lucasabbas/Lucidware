package lucidware.godot;

import lucidware.core.*;

@:native("godot.Vector2")
extern class Vector2Native {
    @:native("__new")
    public function new(x : Float, y : Float);

    @:native("x")
    public var x : Float;

    @:native("y")
    public var y : Float;

    @:native("zero")
    public static var ZERO : Vector2;

    @:native("one")
    public static var ONE : Vector2;

    @:native("inf")
    public static var inf : Vector2;

    @:native("up")
    public static var UP : Vector2;

    @:native("down")
    public static var DOWN : Vector2;

    @:native("left")
    public static var LEFT : Vector2;

    @:native("right")
    public static var RIGHT : Vector2;

    @:native("abs")
    public function abs() : Vector2;

    @:native("angle")
    public function angle() : Float;

    @:native("angleTo")
    public function angleTo(to : Vector2Native) : Float;

    @:native("aspect")
    public function aspect() : Float;

    @:native("bounce")
    public function bounce(n : Vector2Native) : Vector2;

    @:native("ceil")
    public function ceil() : Vector2;

    @:native("clamp")
    public function clamp(min : Vector2Native, max : Vector2Native) : Vector2;

    @:native("clamp")
    public function clampf(min : Float, max : Float) : Vector2;

    @:native("cross")
    public function cross(to : Vector2Native) : Float;

    @:native("cubicInterpolate")
    public function cubicInterpolate(b : Vector2Native, preA : Vector2Native, postB : Vector2Native, weight : Float) : Vector2;

    @:native("cubicInterpolateInTime")
    public function cubicInterpolateInTime(b : Vector2Native, preA : Vector2Native, postB : Vector2Native, weight : Float, t : Float, preAT : Float, postBT : Float) : Vector2;

    @:native("bezierInterpolate")
    public function bezierInterpolate(control1 : Vector2Native, control2 : Vector2Native, end : Vector2Native, t : Float) : Vector2;

    @:native("bezierDerivative")
    public function bezierDerivative(control1 : Vector2Native, control2 : Vector2Native, end : Vector2Native, t : Float) : Vector2;

    @:native("distanceTo")
    public function distanceTo(to : Vector2Native) : Float;

    @:native("distanceSquaredTo")
    public function distanceSquaredTo(to : Vector2Native) : Float;

    @:native("dot")
    public function dot(to : Vector2Native) : Float;

    @:native("floor")
    public function floor() : Vector2;

    @:native("inverse")
    public function inverse() : Vector2;

    @:native("isFinite")
    public function isFinite() : Bool;

    @:native("isNormalized")
    public function isNormalized() : Bool;

    @:native("length")
    public function length() : Float;

    @:native("lerp")
    public function lerp(to : Vector2Native, weight : Float) : Vector2;

    @:native("limitLength")
    public function limitLength(length : Float) : Vector2;

    @:native("max")
    public function max(with : Vector2Native) : Vector2;

    @:native("max")
    public function maxf(with : Float) : Vector2;

    @:native("min")
    public function min(with : Vector2Native) : Vector2;

    @:native("min")
    public function minf(with : Float) : Vector2;

    @:native("maxAxisIndex")
    public function maxAxisIndex() : Int;

    @:native("minAxisIndex")
    public function minAxisIndex() : Int;

    @:native("moveToward")
    public function moveToward(to : Vector2Native, delta : Float) : Vector2;

    @:native("normalized")
    public function normalized() : Vector2;

    @:native("posMof")
    public function posModf(mod : Float) : Vector2;

    @:native("posMod")
    public function posMod(mod : Vector2Native) : Vector2;

    @:native("project")
    public function project(to : Vector2Native) : Vector2;

    @:native("reflect")
    public function reflect(n : Vector2Native) : Vector2;

    @:native("rotated")
    public function rotated(phi : Float) : Vector2;

    @:native("round")
    public function round() : Vector2;

    @:native("sign")
    public function sign() : Vector2;

    @:native("slide")
    public function slide(n : Vector2Native) : Vector2;

    @:native("snapped")
    public function snapped(step : Vector2Native) : Vector2;

    @:native("snapped")
    public function snappedf(step : Float) : Vector2Native;

    @:native("orthogonal")
    public function orthogonal() : Vector2Native;

    @:native("fromAngle")
    public static function fromAngle(angle : Float) : Vector2;

    @:native("toString")
    public function toString() : String;

}


abstract Vector2(Vector2Native) from Vector2Native to Vector2Native {
    public function new(x : Float = 0, y : Float = 0) {
        this = new Vector2Native(x, y);
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
    
        @:op([]) public function arrayRead(n:Dynamic) : Float {
            if (n == 0) return this.x;
            if (n == 1) return this.y;
            if (n == "x") return this.x;
            if (n == "y") return this.y;
            throw "Invalid index";
        }
        
        @:op([]) public function arrayWrite(n:Dynamic, value:Float) {
            if (n == 0) this.x = value;
            else if (n == 1) this.y = value;
            else if (n == "x") this.x = value;
            else if (n == "y") this.y = value;
            else throw "Invalid index";
        }
    
        @:op(A + B)
        public function add(rhs: Any) : Vector2 {
            var lhs = this;
            return untyped __lua__("lhs + rhs");
        }
    
        @:op(A - B)
        public function sub(rhs: Any) : Vector2 {
            var lhs = this;
            return untyped __lua__("lhs - rhs");
        }
    
        @:op(A * B)
        public function mul(rhs: Any) : Vector2 {
            var lhs = this;
            return untyped __lua__("lhs * rhs");
        }
    
        @:op(A / B)
        public function div(rhs: Any) : Vector2 {
            var lhs = this;
            return untyped __lua__("lhs / rhs");
        }
    
        @:op(A % B)
        public function mod(rhs: Any) : Vector2 {
            var lhs = this;
            return untyped __lua__("lhs % rhs");
        }
    
        @:op(A == B)
        public function eq(rhs: Vector2Native) : Bool {
            var lhs = this;
            return untyped __lua__("lhs == rhs");
        }
    
        @:op(A != B)
        public function neq(rhs: Vector2Native) : Bool {
            var lhs = this;
            return untyped __lua__("lhs ~= rhs");
        }
    
        @:op(A < B)
        public function lt(rhs: Vector2Native) : Bool {
            var lhs = this;
            return untyped __lua__("lhs < rhs");
        }
    
        @:op(A <= B)
        public function lte(rhs: Vector2Native) : Bool {
            var lhs = this;
            return untyped __lua__("lhs <= rhs");
        }
    
        @:op(A > B)
        public function gt(rhs: Vector2Native) : Bool {
            var lhs = this;
            return untyped __lua__("lhs > rhs");
        }
    
        @:op(A >= B)
        public function gte(rhs: Vector2Native) : Bool {
            var lhs = this;
            return untyped __lua__("lhs >= rhs");
        }

    public static function toString(v:Vector2Native) {
        return untyped __lua__("v.toString()");
    }
}