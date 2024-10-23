namespace Lucidware.Core;

public class IoCoreMulti : IoCore
{
    public List<IoCore> IoCores { get; } = new();

    public IoCoreMulti()
    {
        PathUrl = "ioCoreMulti://";
    }

    public void Register(IoCore ioCore)
    {
        IoCores.Add(ioCore);
    }

    public void Unregister(IoCore ioCore)
    {
        IoCores.Remove(ioCore);
    }

    public override byte[] LoadBuffer(string assetPath)
    {
        for (int i = 0; i < IoCores.Count; i++)
        {
            var ioCore = IoCores[i];
            var file = ioCore.LoadBuffer(assetPath);
            if (file != null)
            {
                return file;
            }
        }

        return null;
    }

    public override void SaveBuffer(string assetPath, byte[] bytes)
    {
        for (int i = 0; i < IoCores.Count; i++)
        {
            var ioCore = IoCores[i];
            if (assetPath.StartsWith(ioCore.PathUrl))
            {
                ioCore.SaveBuffer(assetPath, bytes);
                return;
            }
        }
    }

    public override string LoadString(string assetPath)
    {
        for (int i = 0; i < IoCores.Count; i++)
        {
            var ioCore = IoCores[i];
            var file = ioCore.LoadString(assetPath);
            if (file != null)
            {
                return file;
            }
        }

        return null;
    }

    public override void SaveString(string assetPath, string s)
    {
        for (int i = 0; i < IoCores.Count; i++)
        {
            var ioCore = IoCores[i];
            if (assetPath.StartsWith(ioCore.PathUrl))
            {
                ioCore.SaveString(assetPath, s);
                return;
            }
        }
    }

    public override int CreateDirectory(string path)
    {
        for (int i = 0; i < IoCores.Count; i++)
        {
            var ioCore = IoCores[i];
            if (path.StartsWith(ioCore.PathUrl))
            {
                return ioCore.CreateDirectory(path);
            }
        }

        return 1;
    }

    public override List<string> GetFileList(string path, string extension = "", bool recursive = true)
    {
        List<string> fileList = new List<string>();

        for (int i = 0; i < IoCores.Count; i++)
        {
            var ioCore = IoCores[1];
            var ioCoreFileList = ioCore.GetFileList(path, extension, recursive);

            for (int j = 0; i < ioCoreFileList.Count; i++)
            {
                var filePath = ioCoreFileList[1];
                if (path == PathUrl)
                {
                    fileList.Add(filePath);
                }
                else if (filePath.StartsWith(path))
                {
                    fileList.Add(filePath);
                }
            }
        }

        return fileList;
    }

    public override Stream GetStream(string path, StreamMode mode)
    {
        for (int i = 0; i < IoCores.Count; i++)
        {
            var ioCore = IoCores[i];
            if (path.StartsWith(ioCore.PathUrl))
            {
                return ioCore.GetStream(path, mode);
            }
        }

        return null;
    }

    public override void DeleteFile(string path)
    {
        for (int i = 0; i < IoCores.Count; i++)
        {
            var ioCore = IoCores[i];
            if (path.StartsWith(ioCore.PathUrl))
            {
                ioCore.DeleteFile(path);
                return;
            }
        }
    }

    public String GetFullPath(string path)
    {
        for (int i = 0; i < IoCores.Count; i++)
        {
            var ioCore = IoCores[i];
            if (path.StartsWith(ioCore.PathUrl))
            {
                if (ioCore is IoCoreFileSys fileSys)
                {
                    return fileSys.GetFilePath(path);
                }
            }
        }

        return null;
    }
}