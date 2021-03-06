using System;
using System.Threading;
using Services.Analytics.UnityAnalytics;

namespace Services.Analytics
{
    internal class AnalyticsManager
    {
        private IAnalyticsService[] _services;
        
        #region Singlton pattern

        private static readonly Lazy<AnalyticsManager> _instance = 
            new Lazy<AnalyticsManager>(() => new AnalyticsManager(), LazyThreadSafetyMode.ExecutionAndPublication);
        
        public static AnalyticsManager Instance => _instance.Value;
        
        private AnalyticsManager()
        {
            InitializeServices();
        }

        #endregion

        private void InitializeServices()
        {
            _services = new IAnalyticsService[]
            {
                new UnityAnalyticsService(),
            };
        }

        public void SendInterstitialAddSkipped() => SendEvent("InterstitialAddSkipped");
        public void SendRewardedAddSkipped() => SendEvent("RewardedAddSlipped");
        public void SendMainMenuOpened() => SendEvent("MainMenuOpened");
        public void SendGameStarted() => SendEvent("GameStarted");

        private void SendEvent(string eventName)
        {
            for (int i = 0; i < _services.Length; i++)
                _services[i].SendEvent(eventName);
            
        }
    }
}