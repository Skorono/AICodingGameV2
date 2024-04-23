namespace AICodingGame.API
{
    public interface IRobot
    {
        void OnHitByBullet();

        void OnHitByRobot();

        void OnHitWall();

        void OnGroundScan();

        void OnEnemyDetect();

        void Run();
    }
}