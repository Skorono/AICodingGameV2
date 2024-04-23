using AICodingGame.API.GameObjects;

namespace AICodingGame.API
{
    public class Robot : Rotator2D, IRobot
    {
        public enum MoveDirection
        {
            Forward = 1,
            Back = -1
        }

        public enum MoveSpeed
        {
            Low = 15,
            Medium = 20,
            High = 25
        }

        public float Energy { get; protected set; } = 100;

        public virtual void OnHitByBullet()
        {
        }

        public virtual void OnHitByRobot()
        {
        }

        public virtual void OnHitWall()
        {
        }

        public virtual void OnGroundScan()
        {
        }

        public virtual void OnEnemyDetect()
        {
        }

        public virtual void Run()
        {
        }
    }
}