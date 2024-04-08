using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    public RobotList robotList;

    public void AddRobot()
    {
        robotList.Add(
            new[] { "Listik", "ExampleRobotasaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", "Kostya" }[
                Random.Range(0, 3)]);
    }
}