using System.Text;
using Godot;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Platforms;
using Script = MoonSharp.Interpreter.Script;

namespace Lucidware.Core;

public class LucidwarePlatformAccessor : PlatformAccessorBase
{
    public LuaEnviroment Enviroment;
    
    public LucidwarePlatformAccessor(LuaEnviroment enviroment)
    {
        Enviroment = enviroment;
    }
    
    public override string GetPlatformNamePrefix()
    {
        return "Lucidware";
    }

    public override void DefaultPrint(string content)
    {
        GD.Print(content);
    }

    public override Stream IO_OpenFile(Script script, string filename, Encoding encoding, string mode)
    {
        StreamMode streamMode;
        switch (mode)
        {
            case "r":
                streamMode = StreamMode.Read;
                break;
            case "w":
                streamMode = StreamMode.Write;
                break;
            case "a":
                streamMode = StreamMode.Append;
                break;
            case "r+":
                streamMode = StreamMode.ReadPlus;
                break;
            case "w+":
                streamMode = StreamMode.WritePlus;
                break;
            case "a+":
                streamMode = StreamMode.AppendPlus;
                break;
            default:
                throw new Exception("Invalid mode");
        }
        
        return Enviroment.IoCore.GetStream(filename, streamMode);
    }

    public override Stream IO_GetStandardStream(StandardFileType type)
    {
        if (type == StandardFileType.StdIn)
        {
            return Enviroment.IoCore.GetStream("stdin", StreamMode.Read);
        }
        else if (type == StandardFileType.StdOut)
        {
            return Enviroment.IoCore.GetStream("stdout", StreamMode.Write);
        }
        else if (type == StandardFileType.StdErr)
        {
            return Enviroment.IoCore.GetStream("stderr", StreamMode.Write);
        }
        else
        {
            throw new Exception("Invalid Standard File Type");
        }
    }

    public override string IO_OS_GetTempFilename()
    {
        return Enviroment.IoCore.GetTempFilename();
    }

    public override void OS_ExitFast(int exitCode)
    {
        Enviroment.Exit(exitCode);
    }

    public override bool OS_FileExists(string file)
    {
        return Enviroment.IoCore.FileExists(file);
    }

    public override void OS_FileDelete(string file)
    {
        Enviroment.IoCore.DeleteFile(file);
    }

    public override void OS_FileMove(string src, string dst)
    {
        Enviroment.IoCore.MoveFile(src, dst);
    }

    public override int OS_Execute(string cmdline)
    {
        throw new NotImplementedException();
    }

    public override CoreModules FilterSupportedCoreModules(CoreModules module)
    {
        return CoreModules.Preset_Complete;
    }

    public override string GetEnvironmentVariable(string envvarname)
    {
        var envVariables = Enviroment.EnviromentVariables;
        foreach (var envKey in envVariables)
        {
            if (envKey.Key == envvarname)
            {
                return envKey.Value;
            }
        }
        
        return null;
    }
}