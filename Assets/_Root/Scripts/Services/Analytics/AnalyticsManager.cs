using Services.Analytics.UnityAnalytics;
using UnityEngine;

namespace Services.Analytics
{
    internal class AnalyticsManager: MonoBehaviour
    {
        private IAnalyticsService[] _services;

        private void Awake()
        {
            InitializeServices();
        }

        private void InitializeServices()
        {
            _services = new IAnalyticsService[]
            {
                new UnityAnalyticsService(),
            };
        }

        public void SendMainMenuOpened() => SendEvent("MainMenuOpened");

        private void SendEvent(string eventName)
        {
            for (int i = 0; i < _services.Length; i++)
                _services[i].SendEvent(eventName);
            
        }
    }
}