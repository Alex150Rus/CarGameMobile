using System;
using System.Threading;
using Services.Analytics.UnityAnalytics;
using UnityEngine;
using UnityEngine.Purchasing;

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

        public void SendTransactionInfo(PurchaseEventArgs purchaseEvent)
        {
            UnityEngine.Analytics.Analytics.Transaction(
                purchaseEvent.purchasedProduct.definition.id,
                purchaseEvent.purchasedProduct.metadata.localizedPrice,
                purchaseEvent.purchasedProduct.metadata.isoCurrencyCode,
                purchaseEvent.purchasedProduct.receipt,
                null
            );
        }

        private void SendEvent(string eventName)
        {
            for (int i = 0; i < _services.Length; i++)
                _services[i].SendEvent(eventName);
        }
    }
}