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
    
    public virtual async Task<string> LoadStringAsync(string assetPath)
    {
        return null;
    }

    public virtual async void SaveStringAsync(string assetPath, string s)
    {
        
    }

    public virtual byte[] LoadBuffer(string assetPath)
    {
        return null;
    }

    public virtual void SaveBuffer(string assetPath, byte[] bytes)
    {

    }
    
    public virtual async Task<byte[]> LoadBufferAsync(string assetPath)
    {
        return null;
    }

    public virtual async void SaveBufferAsync(string assetPath, byte[] bytes)
    {
        
    }

    public List<String> GetFileListAll(string extension, bool recursive = true)
    {
        return GetFileList(PathUrl, extension, recursive);
    }

    public virtual List<String> GetFileList(string path, string extension = "", bool recursive = true)
    {
        return null;
    }

    public virtual int CreateDirectory(string path)
    {
        return 1;
    }
}