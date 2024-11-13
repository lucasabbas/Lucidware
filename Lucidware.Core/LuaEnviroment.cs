using Godot;
using Lucidware.Core.Modules;
using MoonSharp.Interpreter;
using MoonSharp.VsCodeDebugger;
using Script = MoonSharp.Interpreter.Script;

namespace Lucidware.Core;

public class LuaEnviroment
{
    public IoCoreMulti IoCore;

    public Script Script;

    private MoonSharpVsCodeDebugServer server;
    
    public Dictionary<string, string> EnviromentVariables = new();
    
    public List<Module> Modules = new();
    
    private bool _sandboxed = false;
    
    public bool Sandboxed
    {
        get => _sandboxed;
        set
        {
            if (_sandboxed == false)
            {
                _sandboxed = value;
            }
            else
            {
                throw new Exception("Sandbox cannot be turn off once set to true");
            }
        }
    }
    
    public class OnExitEventArgs : EventArgs
    {
        public int ExitCode;
    }
    
    public event EventHandler<OnExitEventArgs> OnExit;
    
    public LuaEnviroment()
    {
        Script = new Script();
        server = new MoonSharpVsCodeDebugServer();
        IoCore = new IoCoreMulti();
        Script.GlobalOptions.Platform = new LucidwarePlatformAccessor(this);
        Script.Options.ScriptLoader = new IoCoreScriptLoader(IoCore);
        Script.Globals["doubleToFloat"] = (Func<double, float>)DoubleToFloat;
        
        UserData.RegisterType<IoCoreMulti>(); // Register the IoCoreMulti type
        Script.Globals["ioCore"] = IoCore;
        
        EnviromentVariables["PLATFORM"] = "Lucidware";
        EnviromentVariables["PLATFORM_VERSION"] = "1.0.0";

        EnviromentVariables["OS_NAME"] = OS.GetName();
        
        AddModule(typeof(Sys));
    }
    
    public void AddModule(Module module)
    {
        Modules.Add(module);
        module.Init();
    }
    
    public void AddModule(Type moduleType)
    {
        var module = (Module)Activator.CreateInstance(moduleType, this);
        Modules.Add(module);
        module.Init();
    }
    
    public void Start(string entryPoint)
    {
        string fullPath = IoCore.GetFullPath(entryPoint);
        GD.Print($"Loading script from path: {fullPath}");

        server.AttachToScript(Script, fullPath, code => fullPath);
        server.Start();
        Script.DoFile(entryPoint);
    }

    public void LoadScript(string path)
    {
        
    }

    public void Exit(int exitCode)
    {
        OnExit?.Invoke(this, new OnExitEventArgs() { ExitCode = exitCode });
    }
    
    public float DoubleToFloat(double d)
    {
        return (float)d;
    }
}