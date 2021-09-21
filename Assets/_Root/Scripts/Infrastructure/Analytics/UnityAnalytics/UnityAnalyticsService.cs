using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

namespace Services.Analytics.UnityAnalytics
{
    internal class UnityAnalyticsService: IAnalyticsService
    {
        public void SendEvent(string eventName) =>
            UnityEngine.Analytics.Analytics.CustomEvent(eventName);

        public void SendEvent(string eventName, Dictionary<string, object> eventData) =>
            UnityEngine.Analytics.Analytics.CustomEvent(eventName, eventData);

        public void SendTransaction(PurchaseEventArgs purchaseEvent)
        {
            UnityEngine.Analytics.Analytics.Transaction(
                purchaseEvent.purchasedProduct.definition.id,
                purchaseEvent.purchasedProduct.metadata.localizedPrice,
                purchaseEvent.purchasedProduct.metadata.isoCurrencyCode,
                purchaseEvent.purchasedProduct.receipt,
                null
            );
            Debug.Log("Transaction info sent");
        }
    }
}