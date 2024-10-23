using System.IO.Compression;

namespace LucidKit.Core;

public class IoCoreZip : IoCore
{
    ZipArchive zipArchive;
    
    public IoCoreZip(string path, string pathUrl)
    {
        PathUrl = pathUrl;
        if (path.EndsWith(".spkg") || path.EndsWith(".zip"))
        {
            zipArchive = ZipFile.OpenRead(path);
        }
        else
        {
            throw new Exception("Invalid Zip File");
        }
    }

    public IoCoreZip(byte[] buffer, string pathUrl)
    {
        PathUrl = pathUrl;
        MemoryStream ms = new MemoryStream(buffer);
        zipArchive = new ZipArchive(ms);
    }
    
    public string GetFilePath(string path)
    {
        if (path.StartsWith(PathUrl))
        {
            path = path.Replace(PathUrl, "");
            if (path == null)
            {
                throw new Exception("Path Conversion Error");
            }
        }
        else if (path.StartsWith("./"))
        {
            path = path.Replace("./", "");
            if (path == null)
            {
                throw new Exception("Path Conversion Error");
            }
        }
        if (path.Contains("/"))
        {
            path = path.Replace("\\/", "/");
            path = path.Replace("\\", "/");
        }
        if (path.Contains("/"))
        {
            path = path.Replace("/", "\\");
        }
        return path;
    }

    public string SanitizePath(string path)
    {
        path = path.Replace("\\/", "\\");
        path = path.Replace("\\", "/");
        return path;
    }
    
    public override string LoadString(string assetPath)
    {
        string path = GetFilePath(assetPath);
        ZipArchiveEntry entry = zipArchive.GetEntry(path);
        if (entry == null)
        {
            return null;
        }
        using (StreamReader reader = new StreamReader(entry.Open()))
        {
            return reader.ReadToEnd();
        }
    }

    public override byte[] LoadBuffer(string assetPath)
    {
        string path = GetFilePath(assetPath);
        ZipArchiveEntry entry = zipArchive.GetEntry(path);
        if (entry == null)
        {
            return null;
        }
        using (MemoryStream ms = new MemoryStream())
        {
            entry.Open().CopyTo(ms);
            return ms.ToArray();
        }
    }

    public override List<string> GetFileList(string path, string extension = "", bool recursive = true)
    {
        path = GetFilePath(path);
        List<string> assets = new List<string>();
        foreach (var entry in zipArchive.Entries)
        {
            if (extension != "")
            {
                if (entry.FullName.StartsWith(path) && entry.FullName.EndsWith(extension))
                {
                    assets.Add(PathUrl + SanitizePath(entry.FullName));
                }
            }
            else
            {
                if (entry.FullName.StartsWith(path))
                {
                    assets.Add(PathUrl + SanitizePath(entry.FullName));
                }
            }
        }
        return assets;
    }

    public override Stream GetStream(string path)
    {
        path = GetFilePath(path);
        ZipArchiveEntry entry = zipArchive.GetEntry(path);
        if (entry == null)
        {
            return null;
        }
        return entry.Open();
    }
}