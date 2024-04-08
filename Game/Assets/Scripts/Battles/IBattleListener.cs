namespace Assets.Scripts.Battles
{
    /// <summary>
    ///     Listener of battle events
    /// </summary>
    internal interface IBattleListener
    {
        void OnBattleStarted();

        void OnBattleEnded();

        void OnTurnStarted();

        void OnTurnEnded();
    }
}