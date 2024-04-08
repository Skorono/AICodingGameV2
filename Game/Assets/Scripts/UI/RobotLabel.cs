using UnityEngine;
using UnityEngine.UI;

public class RobotLabel : MonoBehaviour
{
    private Button _button;

    [SerializeField] public string RobotName => _button.GetComponent<Text>().text;


    private void Start()
    {
        _button = GetComponent<Button>();
    }
}