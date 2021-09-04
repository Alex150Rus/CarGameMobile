using System;
using System.Threading;
using Services.Ads.UnityAds;
using Services.Analytics.UnityAnalytics;
using Tools.Logger;
using UnityEngine;

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

        public void SendMainMenuOpened() => SendEvent("MainMenuOpened");

        private void SendEvent(string eventName)
        {
            for (int i = 0; i < _services.Length; i++)
                _services[i].SendEvent(eventName);
            
        }
    }
}