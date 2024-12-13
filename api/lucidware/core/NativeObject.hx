package lucidware.core;

extern class NativeObject {
    @:native("__new")
    public static function createInstance() : Dynamic;
}