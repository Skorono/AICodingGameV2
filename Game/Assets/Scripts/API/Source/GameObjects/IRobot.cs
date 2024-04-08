using AICodingGame.API.Data.EventInfo.Hit;
using AICodingGame.API.Data.EventInfo.Scanner;

namespace AICodingGame.API
{
    public interface IRobot
    {
        void OnHitByBullet(BulletHit hit);

        void OnHitByRobot(RobotHit hit);

        void OnHitWall(WallHit hit);

        void OnEnemyDetect(RobotInfo info);

        void OnWallDetect();

        void Run();
    }
}