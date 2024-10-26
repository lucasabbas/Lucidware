using Godot;
using Lucidware.Core.Modules;

namespace Lucidware.Core;

public partial class LuaNode : Node
{
    private LuaEnviroment _luaEnviroment;
    
    private String _mainScriptPath = "app://main.lua";
    
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
}