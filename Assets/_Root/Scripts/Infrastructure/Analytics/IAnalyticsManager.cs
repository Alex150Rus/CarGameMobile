namespace Services.Analytics
{
    internal interface IAnalyticsManager
    {
        public void SendInterstitialAddSkipped();
        public void SendRewardedAddSkipped();
        public void SendMainMenuOpened();
        public void SendGameStarted();
    }
}