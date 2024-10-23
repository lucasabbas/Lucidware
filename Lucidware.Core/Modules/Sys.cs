using MoonSharp.Interpreter;

namespace Lucidware.Core.Modules;

public class Sys : Module
{
    public Sys(LuaEnviroment luaEnviroment) : base(luaEnviroment)
    {
    }

    public override void Init()
    {
        Table SysNamespace = new Table(LuaEnviroment.Script);
        LuaEnviroment.Script.Globals["sys"] = SysNamespace;
        
        UserData.RegisterType<IoCoreMulti>();
        UserData.RegisterType<IoCoreFileSys>();
        UserData.RegisterType<IoCoreZip>();

        SysNamespace["IoCoreMulti"] = IoCoreMulti;
        SysNamespace["IoCoreFileSys"] = IoCoreFileSys;
        SysNamespace["IoCoreZip"] = IoCoreZip;
        
    }

    public IoCoreMulti IoCoreMulti()
    {
        return new IoCoreMulti();
    }
    
    public IoCoreFileSys IoCoreFileSys(String path, string pathUrl)
    {
        return new IoCoreFileSys(path, pathUrl);
    }
    
    public IoCoreZip IoCoreZip(byte[] data, String pathUrl)
    {
        return new IoCoreZip(data, pathUrl);
    }
}