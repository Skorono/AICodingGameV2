using JetBrains.Annotations;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RobotList : MonoBehaviour
{
    public GameObject ContentItem;

    public ScrollRect ScrollRect;
    public GameObject SelectedItem;

    private void Awake()
    {
        ScrollRect = gameObject.GetComponent<ScrollRect>();
    }

    public void Add(string name)
    {
        var newRobotLabel = Instantiate(ContentItem);

        newRobotLabel.GetComponent<Button>().onClick.AddListener(() =>
        {
            SelectedItem = newRobotLabel;
            Debug.Log($"ֱûכ גûבנאם נמבמע: \"{name}\"");
        });
        newRobotLabel.GetComponentInChildren<TextMeshProUGUI>().text = name;
        newRobotLabel.transform.SetParent(ScrollRect.content, false);
    }

    public void RemoveSelectedLabel()
    {
        Destroy(SelectedItem);
    }

    public void RemoveAllLabels()
    {
        for (var i = 0; i < ScrollRect.content.childCount; i++)
            Destroy(ScrollRect.content.GetChild(i).gameObject);
    }

    [CanBeNull]
    public IEnumerable<GameObject> GetChilds()
    {
        List<GameObject> childs = new();

        if (ScrollRect != null)
            for (var i = 0; i < ScrollRect.content.childCount; ++i)
                childs.Add(ScrollRect.content.GetChild(i).gameObject);

        return childs;
    }
}