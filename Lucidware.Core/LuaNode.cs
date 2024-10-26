using Godot;
using Lucidware.Core.Modules;

namespace Lucidware.Core;

public partial class LuaNode : Node
{
    private LuaEnviroment _luaEnviroment;
    
    private String _mainScriptPath = "app://main.lua";
    
    [Signal] public delegate void MainEventHandler();
    [Signal] public delegate void UpdateEventHandler(float delta);
    [Signal] public delegate void PhysicsUpdateEventHandler(float delta);
    [Signal] public delegate void InputEventHandler(InputEvent @event);
    [Signal] public delegate void UnhandledInputEventHandler(InputEvent @event);
    [Signal] public delegate void ShortcutInputEventHandler(InputEvent @event);
    [Signal] public delegate void UnhandledKeyInputEventHandler(InputEvent @event);
    [Signal] public delegate void StopEventHandler();
    
    public LuaNode()
    {
        _luaEnviroment = new LuaEnviroment();
        _luaEnviroment.AddModule(typeof(GodotModule));
        _luaEnviroment.Script.Globals["rootNode"] = this;
    }
    
    public void StartFromPath(string path)
    {
        IoCoreFileSys fileSys = new IoCoreFileSys(path, "app://");
        _luaEnviroment.IoCore.Register(fileSys);
        _luaEnviroment.Start(_mainScriptPath);
    }
    
    public void StartFromZipFile(byte[] data)
    {
        IoCoreZip zip = new IoCoreZip(data, "app://");
        _luaEnviroment.IoCore.Register(zip);
        _luaEnviroment.Start(_mainScriptPath);
    }
    
    public void StartFromZipFile(string path)
    {
        IoCoreZip zip = new IoCoreZip(path, "app://");
        _luaEnviroment.IoCore.Register(zip);
        _luaEnviroment.Start(_mainScriptPath);
    }
    
    private float DoubleToFloat(double d)
    {
        return (float)d;
    }
    
    public override void _Process(double delta)
    {
        EmitSignal(SignalName.Update, DoubleToFloat(delta));
    }

    public override void _PhysicsProcess(double delta)
    {
        EmitSignal(SignalName.PhysicsUpdate, DoubleToFloat(delta));
    }

    public override void _Input(InputEvent @event)
    {

        EmitSignal(SignalName.Input, @event);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        EmitSignal(SignalName.UnhandledInput, @event);
    }

    public override void _ShortcutInput(InputEvent @event)
    {
        EmitSignal(SignalName.ShortcutInput, @event);
    }

    public override void _UnhandledKeyInput(InputEvent @event)
    {
        EmitSignal(SignalName.UnhandledKeyInput, @event);
    }

    public override void _ExitTree()
    {
        EmitSignal(SignalName.Stop);
    }
}