using System;
using System.Collections.Generic;
using System.Linq;
using AICodingGame.API;
using AICodingGame.API.GameObjects;
using UnityEngine;

public class TestObserver : MonoBehaviour
{
    [SerializeField] private List<BasicRobot> _robots = new();
    // Start is called before the first frame update

    public GameObject BulletPrefab;
    public Action OnTurnEnd;

    public Action OnTurnStart;
    public GameObject Spawner;

    private void Start()
    {
        var robotsObj = new List<GameObject> { GameObject.Find("Player") };

        robotsObj.ForEach(delegate(GameObject o)
        {
            o.transform.Find("RobotBody").Find("Gun").gameObject.AddComponent(typeof(RobotGun));
            o.transform.Find("RobotBody").Find("Radar").gameObject.AddComponent(typeof(RobotScanner));
            o.AddComponent(typeof(MyFirstRobot.MyFirstRobot));
            o.GetComponent<BasicRobot>().BulletPrefab = BulletPrefab;
        });

        _robots = robotsObj.Select(r => r.GetComponent<BasicRobot>()).ToList();
        _robots.ForEach(delegate(BasicRobot robot)
        {
            OnTurnStart += robot.Execute;
            OnTurnEnd += robot.OnScan;
        });

        //StartCoroutine(TurnExecution());
    }


    private void Update()
    {
        OnTurnStart();
        new WaitForSeconds(1);
        OnTurnEnd();
    }
}