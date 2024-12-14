import lucidware.godot.Vector3;
import lucidware.godot.Vector2;

class Main {
    public static function main() {
        trace("Hello, World!");
        var vec3_1 = new Vector3(1, 2, 3);
        trace(vec3_1.toString());
        var vec3_2 = new Vector3(4, 5, 6);
        trace(vec3_2.toString());
        var vec3_3 = vec3_1 + vec3_2;
        trace(vec3_3);

        var vec2_1 = new Vector2(1, 2);
        trace(vec2_1.toString());
        var vec2_2 = new Vector2(3, 4);
        trace(vec2_2.toString());
        var vec2_3 = vec2_1 + vec2_2;
        trace(vec2_3);
    }
}