using System;
using System.Threading;
using Services.Ads.UnityAds.Settings;
using Tools;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;

namespace Services.Ads.UnityAds
{
    internal class UnityAdsService : MonoBehaviour, IAdsService, IUnityAdsInitializationListener
    {
        [SerializeField] private UnityAdsSettings _settings;

        public UnityEvent Initialized { get; private set; } = new UnityEvent();

        public UnityAdsPlayer InterstitialPlayer { get; private set; }
        public UnityAdsPlayer RewardedPlayer { get; private set; }
        public UnityAdsPlayer BannerPlayer { get; private set; }

        private void Awake()
        {
            InitializeAds();
            InitializePlayers();
        }

        private void InitializePlayers()
        {
            InterstitialPlayer = CreateInterstitial();
            RewardedPlayer = CreateRewarded();
            BannerPlayer = CreateBanner();
        }

        private UnityAdsPlayer CreateBanner() => new EmptyPlayer("");

        private UnityAdsPlayer CreateRewarded() => _settings.Rewarded.Enabled
            ? new RewardedPlayer(_settings.Rewarded.Id)
            : (UnityAdsPlayer) new EmptyPlayer("");

        private UnityAdsPlayer CreateInterstitial() => _settings.Interstitial.Enabled
            ? new InterstitialPlayer(_settings.Interstitial.Id)
            : (UnityAdsPlayer) new EmptyPlayer("");

        private void InitializeAds() => Advertisement.Initialize(
            _settings.GameId,
            _settings.TestMode,
            _settings.EnablePerPlacementMode,
            this
        );


        public void OnInitializationComplete()
        {
            Debug.Log("Unity Ads Initialization complete.");
            Initialized?.Invoke();
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            Debug.Log($"Unity Ads Initialization Filed: {error.ToString()} - {message}.");
        }
    }
}