using Godot;

namespace Lucidware.Core;

public partial class SimpleRuntimeNode : Node
{
    public LuaNode LuaNode;
    
    public override void _Ready()
    {
        var args = OS.GetCmdlineArgs();
        for (var i = 0; i < args.Length; i++)
        {
            if (args[i].StartsWith("--dirpath="))
            {
                var p = args[i].Replace("--dirpath=", "");
                StartFromPath(p);
            }
            else if (args[i].StartsWith("--spkgpath="))
            {
                var p = args[i].Replace("--spkgpath=", "");
                StartFromZipFile(p);
            }
        }
    }
    
    public void StartFromPath(string path)
    {
        LuaNode = new LuaNode();
        AddChild(LuaNode);
        LuaNode.StartFromPath(path);
    }

    public void StartFromZipFile(String path)
    {
        LuaNode = new LuaNode();
        AddChild(LuaNode);
        LuaNode.StartFromZipFile(path);
    }
}