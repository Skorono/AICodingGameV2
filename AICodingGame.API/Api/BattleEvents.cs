namespace AICodingGame.API
{
    public static class BattleEventsData
    {
        public delegate BattleStates.HitInfo OnHit(Collision collision);

        public static event OnHit HitEvent;
    }
}