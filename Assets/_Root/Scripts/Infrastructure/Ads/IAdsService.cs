using Services.Ads.UnityAds;
using UnityEngine.Events;

namespace Services.Ads
{
    internal interface IAdsService
    {
        public UnityEvent Initialized { get; }

        public UnityAdsPlayer InterstitialPlayer { get; }
        public UnityAdsPlayer RewardedPlayer { get; }
        public UnityAdsPlayer BannerPlayer { get; }
    }
}