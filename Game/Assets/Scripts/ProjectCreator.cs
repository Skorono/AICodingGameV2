using System.Diagnostics;
using System.Xml.Linq;
using UnityEngine;

public class ProjectCreator : MonoBehaviour
{
    // Start is called before the first frame update
    public void CreateProject(string projectName)
    {
        var process = new Process();
        process.StartInfo.FileName = "dotnet";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;

        process.StartInfo.Arguments = $"new console -n {projectName}";

        process.Start();
        process.WaitForExit();
    }

    private void AddReferences(string projectPath)
    {
        // Путь к файлу .csproj
        var csprojPath = "path/to/your/project.csproj";

        // Загрузка файла .csproj
        var csproj = XDocument.Load(csprojPath);

        // Настройка места сборки
        csproj.Root.Element("PropertyGroup").Element("OutputPath").Value = "path/to/your/output/directory";

        // Добавление ссылки на библиотеку
        var reference = new XElement("Reference", new XAttribute("Include", "YourLibrary"));
        reference.Add(new XElement("HintPath", "path/to/your/library/dll"));
        csproj.Root.Element("ItemGroup").Add(reference);

        // Сохранение изменений в файле .csproj
        csproj.Save(csprojPath);
    }
}