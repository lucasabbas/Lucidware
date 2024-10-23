using MoonSharp.Interpreter;

namespace LucidKit.Core;

public class LuaEnviroment
{
    public IoCoreMulti IoCore;

    public Script Script;

    LuaEnviroment()
    {
        Script = new Script();
    }

    public void LoadScript(string path)
    {
        
    }
}