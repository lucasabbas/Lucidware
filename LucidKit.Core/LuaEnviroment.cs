using Godot;
using LucidKit.Core.Modules;
using MoonSharp.Interpreter;
using MoonSharp.VsCodeDebugger;
using Script = MoonSharp.Interpreter.Script;

namespace LucidKit.Core;

public class LuaEnviroment
{
    public IoCoreMulti IoCore;

    public Script Script;

    private MoonSharpVsCodeDebugServer server;
    
    public Dictionary<string, string> EnviromentVariables = new();
    
    public List<Module> Modules = new();
    
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
        Script.GlobalOptions.Platform = new LucidKitPlatformAccessor(this);
        Script.Options.ScriptLoader = new IoCoreScriptLoader(IoCore);
        
        UserData.RegisterType<IoCoreMulti>(); // Register the IoCoreMulti type
        Script.Globals["ioCore"] = IoCore;
        
        EnviromentVariables["PLATFORM"] = "LucidKit";
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
}