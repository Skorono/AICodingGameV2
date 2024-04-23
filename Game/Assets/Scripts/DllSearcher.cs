using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

public static class DllSearcher
{
    [CanBeNull]
    public static string[] GetDllNamesFromPath(string path)
    {
        return Directory.Exists(path) ? Directory.GetFiles(path).Where(f => f.EndsWith(".dll")).ToArray() : null;
    }

    [CanBeNull]
    public static string FindDll(string path, string dllName)
    {
        foreach (var dir in Directory.GetDirectories(path))
        {
            string? dllPath = Directory.GetFiles(dir).FirstOrDefault(f => Path.GetFileName(f) == $"{dllName}.dll");
            if (dllPath == null)
                Directory.GetDirectories(dir)?.Select(dir => FindDll(dir, dllName));
            else
                return dllPath;
        }

        return null;
    }
}