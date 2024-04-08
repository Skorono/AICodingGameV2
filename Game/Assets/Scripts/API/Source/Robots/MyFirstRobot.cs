using System;
using AICodingGame.API;
using AICodingGame.API.Data.EventInfo.Hit;
using AICodingGame.API.Data.EventInfo.Scanner;
using AICodingGame.API.GameObjects;

namespace MyFirstRobot
{
    public class MyFirstRobot : BasicRobot
    {
        public override void OnWallDetect()
        {
            throw new NotImplementedException();
        }

        public override void Run()
        {
            //TurnBody(90);
            Move(1, MoveSpeed.Low, MoveDirection.Forward);
            TurnBody(-90);
            TurnRobotGun(20);
        }

        public override void OnHitByBullet(BulletHit hit)
        {
        }

        public override void OnHitByRobot(RobotHit hit)
        {
        }

        public override void OnHitWall(WallHit hit)
        {
            Move(5, MoveSpeed.High, MoveDirection.Back);
            TurnBody(45);
        }

        public override void OnEnemyDetect(RobotInfo info)
        {
            Fire(RobotGun.FirePower.High);
        }
    }
}