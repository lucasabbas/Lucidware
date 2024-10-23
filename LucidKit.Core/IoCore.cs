namespace LucidKit.Core;

public abstract class IoCore
{
    public String PathUrl = "files://";

    public virtual String LoadString(string assetPath)
    {
        return null;
    }

    public virtual void SaveString(string assetPath, string s)
    {

    }

    public virtual byte[] LoadBuffer(string assetPath)
    {
        return null;
    }

    public virtual void SaveBuffer(string assetPath, byte[] bytes)
    {

    }

    public virtual List<String> GetFileListAll(string extension, bool recursive = true)
    {
        return null;
    }

    public virtual List<String> GetFileList(string path = "", string extension = "", bool recursive = true)
    {
        return null;
    }

    public virtual int CreateDirectory(string path)
    {
        return 1;
    }
}