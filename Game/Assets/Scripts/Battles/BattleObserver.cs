using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AICodingGame.API;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = Unity.Mathematics.Random;

namespace AICodingGame
{
    public class BattleObserver : MonoBehaviour
    {
        private static int _turnsCompleted;

        private readonly DllRobotFactory _robotFactory = new();

        private readonly List<BasicRobot> _robots = new();
        [SerializeField] private GameObject bulletPrefab;

        [SerializeField] private GameObject robotPrefab;

        private void Awake()
        {
            _robotFactory.RobotPrefab = robotPrefab;
        }

        private void Start()
        {
            var battleSettings = GameObject.FindGameObjectWithTag(ObjectsTags.BuildSettingsObject)
                .GetComponent<BuildBattleController>();
            var robotContainer = GameObject.FindGameObjectWithTag(ObjectsTags.RobotNamesList).gameObject
                .GetComponent<ScrollRect>();

            for (var i = 0; i < robotContainer.content.childCount; i++)
            {
                var robotPath = Path.Combine(battleSettings.RobotDir,
                    $"{robotContainer.content.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text}.dll");

                var robotObj = _robotFactory.Make(robotPath);
                robotObj.transform.SetParent(GameObject.FindGameObjectWithTag(ObjectsTags.Spawner).transform);
                robotObj.transform.position = new Vector3(new Random().NextInt(-7, 8), new Random().NextInt(-4, 4), -1);

                var robot = (BasicRobot)robotObj.GetComponent(DllLoader.LoadTypeFromDll<BasicRobot>(robotPath));

                if (robot != null)
                {
                    robot.BulletPrefab = bulletPrefab;
                    OnTurnStart += robot.Execute;
                    OnTurnEnd += robot.OnScan;
                    _robots.Add(robot);
                }
            }
        }

        private void Update()
        {
            OnTurnStart?.Invoke();
            OnTurnEnd?.Invoke();

            if (_robots.Count(r => r.Energy == 0f) == _robots.Count - 1) SceneManager.LoadScene("Menu");
            /*var battleInfo = new BattleInfo();
                battleInfo.Robots = new List<RobotDTO>(_robots.Select(r => new RobotDTO(((BasicRobot)r.GetComponent<BasicRobot>()).name)));
                battleInfo.startTime = DateTime.Now;
                battleInfo.endTime = DateTime.Now;
                battleInfo.winner = new RobotDTO(((BasicRobot)_robots.First().GetComponent<BasicRobot>()).name);
                BattleLogger.WriteBattleLogs(battleInfo);*/
        }

        private event Action OnTurnStart;
        private event Action OnTurnEnd;

        private void OnRobotCompleteTurn()
        {
            _turnsCompleted++;
        }

        //if (OnTurnStart != null)
        // OnTurnStart();

        //new TaskFactory().StartNew(() => Thread.Sleep(100)).Wait();
    }
}