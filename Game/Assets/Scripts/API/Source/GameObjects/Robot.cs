using AICodingGame.API.Data.EventInfo.Hit;
using AICodingGame.API.Data.EventInfo.Scanner;
using API.Source.GameObjects;
using Unity.VisualScripting;

namespace AICodingGame.API
{
    public abstract class Robot : MovableObject, IRobot
    {
        [Serialize] public int HP { get; protected set; } = 100;

        [Serialize] public float Energy { get; protected set; } = 100;

        private void Update()
        {
            if (HP <= 0 || Energy <= 0)
                gameObject.SetActive(false);
        }

        public abstract void OnHitByBullet(BulletHit hit);
        public abstract void OnHitByRobot(RobotHit hit);
        public abstract void OnHitWall(WallHit hit);
        public abstract void OnEnemyDetect(RobotInfo info);
        public abstract void OnWallDetect();
        public abstract void Run();
    }
}