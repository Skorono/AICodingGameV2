using AICodingGame.API;
using AICodingGame.API.GameObjects;
using JetBrains.Annotations;
using UnityEngine;

namespace AICodingGame
{
    public class DllRobotFactory : MonoBehaviour, IRobotFactory
    {
        [CanBeNull] public GameObject RobotPrefab;

        [CanBeNull]
        public GameObject Make(string path)
        {
            var robotPrefab = Instantiate(RobotPrefab, new Vector3(0, 0, 0), Quaternion.identity);

            var type = DllLoader.LoadTypeFromDll<BasicRobot>(path);
            robotPrefab.AddComponent(type);

            if (robotPrefab != null && type != null)
            {
                robotPrefab.transform.Find("RobotBody").Find("Gun").gameObject.AddComponent(typeof(RobotGun));
                robotPrefab.transform.Find("RobotBody").Find("Radar").gameObject.AddComponent(typeof(RobotScanner));
            }

            return robotPrefab;
        }
    }
}