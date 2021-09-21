using System;
using System.Threading;
using Services.Analytics.UnityAnalytics;
using UnityEngine;

namespace Services.Analytics
{
    internal class AnalyticsManager : MonoBehaviour, IAnalyticsManager
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