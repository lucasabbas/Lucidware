import lucidware.godot.Vector3;

class Main {
    public static function main() {
        trace("Hello, World!");
        var vec3_1 = new Vector3(1, 2, 3);
        trace(vec3_1.toString());
        var vec3_2 = new Vector3(4, 5, 6);
        trace(vec3_2.toString());
        var vec3_3 = vec3_1 + vec3_2;
        trace(vec3_3);
    }
}