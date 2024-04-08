using TMPro;
using UnityEngine;

public class ListController : MonoBehaviour
{
    public RobotList AddedRobotList;

    // Start is called before the first frame update
    public RobotList RobotContainer;

    public void AddRobotLabel()
    {
        if (RobotContainer.SelectedItem != null)
        {
            AddedRobotList.Add(RobotContainer.SelectedItem.GetComponentInChildren<TextMeshProUGUI>().text);
            Debug.Log(
                $"Был добавлен робот \"{RobotContainer.SelectedItem.GetComponentInChildren<TextMeshProUGUI>().text}\"");
        }
    }

    public void AddAllRobotLabels()
    {
        for (var i = 0; i < RobotContainer.ScrollRect.content.childCount; i++)
            AddedRobotList.Add(RobotContainer.ScrollRect.content.GetChild(i).GetComponentInChildren<TextMeshProUGUI>()
                .text);
    }

    public void RemoveRobot()
    {
        AddedRobotList.RemoveSelectedLabel();
    }

    public void RemoveAllRobots()
    {
        AddedRobotList.RemoveAllLabels();
    }
}