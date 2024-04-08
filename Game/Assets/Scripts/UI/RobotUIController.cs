using AICodingGame.API;
using TMPro;
using UnityEngine;

public class RobotUIController : MonoBehaviour
{
    // Start is called before the first frame update
    private BasicRobot _robot;
    private TextMeshProUGUI EnergyStatus;
    private TextMeshProUGUI HPStatus;
    private TextMeshProUGUI Name;

    private void Awake()
    {
        Name = transform.Find("Canvas").Find("NamePoint")
            .GetComponentInChildren<TextMeshProUGUI>();
        EnergyStatus = transform.Find("Canvas").Find("EnergyPoint")
            .GetComponentInChildren<TextMeshProUGUI>();
        HPStatus = transform.Find("Canvas").Find("EnergyPoint")
            .GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        _robot = GameObject.FindGameObjectWithTag("Robot").gameObject.GetComponent<BasicRobot>();
        Name.text = _robot.name;
        //transform.Find("NamePoint").gameObject.GetComponentInChildren<TextMeshProUGUI>().text = nameof(_robot);
        //transform.Find("EnergyPoint").gameObject.GetComponentInChildren<TextMeshProUGUI>().text = _robot.Energy.ToString();
    }

    private void Update()
    {
        Name.transform.position =
            transform.Find("Canvas").Find("NamePoint").transform.position;

        EnergyStatus.transform.position =
            transform.Find("Canvas").Find("EnergyPoint").transform.position;
        /*HPStatus.transform.position =  */
        if (!gameObject.activeSelf)
            transform.Find("EnergyPoint").gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Deactivated";
    }
}