using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Loaders;

namespace Lucidware.Core;

public class IoCoreScriptLoader : ScriptLoaderBase
{
    private IoCore _ioCore;
    
    public IoCoreScriptLoader(IoCore ioCore)
    {
        _ioCore = ioCore;
    }
    
    public override bool ScriptFileExists(string name)
    {
        return _ioCore.FileExists(name);
    }

    public override object LoadFile(string file, Table globalContext)
    {
        return _ioCore.LoadString(file);
    }

    public override string ResolveFileName(string filename, Table globalContext)
    {
        return filename;
    }
    
    public override string ResolveModuleName(string modname, Table globalContext)
    {
        return modname;
    }
}