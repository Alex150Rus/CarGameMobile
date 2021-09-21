using System;
using Services.Ads;
using Services.Ads.UnityAds;
using Services.Analytics;
using Services.Shop;
using UnityEngine;

namespace Infrastructure
{
    internal class Services : MonoBehaviour
    {
        [SerializeField] private UnityAdsService _adsService;
        [SerializeField] private ShopTools _shop;
        [SerializeField] private AnalyticsManager _analyticsManager;
        
        private static Services s_instance;
        private static Services Instance => s_instance ??= FindObjectOfType<Services>();

        public static IAdsService Ads => s_instance._adsService;
        public static IShop Shop => s_instance._shop;
        public static IAnalyticsManager Analytics => s_instance._analyticsManager;

        private Services _prevInstanceCache;

        private void Awake()
        {
            if(s_instance == this)
                return;

            _prevInstanceCache = s_instance;
            s_instance = this;
        }

        private void OnDestroy()
        {
            s_instance = _prevInstanceCache;
            _prevInstanceCache = null;
        }
    }
}