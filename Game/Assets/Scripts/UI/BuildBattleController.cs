using System.IO;
using System.Linq;
using AICodingGame;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildBattleController : MonoBehaviour
{
    public string RobotDir { get; } = Path.Combine(Directory.GetCurrentDirectory(), "robots");

    private void OnEnable()
    {
        var robotContainer = GameObject.FindGameObjectWithTag(ObjectsTags.RobotContainerMenu).GetComponent<RobotList>();

        foreach (var dllName in DllSearcher.GetDllNamesFromPath(RobotDir))
        {
            var robotName = Path.GetFileName(dllName).Split('.').First();
            if (robotContainer.GetChilds()
                    .FirstOrDefault(obj => obj.GetComponentInChildren<TextMeshProUGUI>().text == robotName) == null)
                robotContainer.Add(robotName);
        }
    }

    public void OnBattleStart()
    {
        SceneManager.LoadScene("BattleScene", LoadSceneMode.Additive);
    }
}