using JetBrains.Annotations;
using System.IO;
using System.Linq;

public static class DllSearcher
{
    [CanBeNull]
    public static string[] GetDllNamesFromPath(string path)
    {
        return Directory.Exists(path) ? Directory.GetFiles(path).Where(f => f.EndsWith(".dll")).ToArray() : null;
    }
}