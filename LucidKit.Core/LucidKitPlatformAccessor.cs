using System.Text;
using Godot;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Platforms;
using Script = MoonSharp.Interpreter.Script;

namespace LucidKit.Core;

public class LucidKitPlatformAccessor : PlatformAccessorBase
{
    public LuaEnviroment Enviroment;
    
    LucidKitPlatformAccessor(LuaEnviroment enviroment)
    {
        Enviroment = enviroment;
    }
    
    public override string GetPlatformNamePrefix()
    {
        return "LucidKit";
    }

    public override void DefaultPrint(string content)
    {
        GD.Print(content);
    }

    public override Stream IO_OpenFile(Script script, string filename, Encoding encoding, string mode)
    {
        throw new NotImplementedException();
    }

    public override Stream IO_GetStandardStream(StandardFileType type)
    {
        throw new NotImplementedException();
    }

    public override string IO_OS_GetTempFilename()
    {
        throw new NotImplementedException();
    }

    public override void OS_ExitFast(int exitCode)
    {
        throw new NotImplementedException();
    }

    public override bool OS_FileExists(string file)
    {
        throw new NotImplementedException();
    }

    public override void OS_FileDelete(string file)
    {
        throw new NotImplementedException();
    }

    public override void OS_FileMove(string src, string dst)
    {
        throw new NotImplementedException();
    }

    public override int OS_Execute(string cmdline)
    {
        throw new NotImplementedException();
    }

    public override CoreModules FilterSupportedCoreModules(CoreModules module)
    {
        throw new NotImplementedException();
    }

    public override string GetEnvironmentVariable(string envvarname)
    {
        throw new NotImplementedException();
    }
}