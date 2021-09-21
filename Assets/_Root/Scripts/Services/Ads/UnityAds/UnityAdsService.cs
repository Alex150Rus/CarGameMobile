using System;
using System.Threading;
using Services.Ads.UnityAds.Settings;
using Tools;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;

namespace Services.Ads.UnityAds
{
    internal class UnityAdsService: IAdsService, IUnityAdsInitializationListener
    {
       private UnityAdsSettings _settings;
       private readonly ResourcePath _settingsPath = new ResourcePath("Settings/UnityAdsSettings");

       public UnityEvent Initialized { get; private set; } = new UnityEvent();

        
        public UnityAdsPlayer InterstitialPlayer { get; private set; }
        public UnityAdsPlayer RewardedPlayer { get; private set; }
        public UnityAdsPlayer BannerPlayer { get; private set; }

        #region Singlton pattern

        private static readonly Lazy<UnityAdsService> _instance = 
            new Lazy<UnityAdsService>(() => new UnityAdsService(), LazyThreadSafetyMode.ExecutionAndPublication);
        
        public static UnityAdsService Instance => _instance.Value;
        
        private UnityAdsService()
        {
            LoadSettings();
            InitializeAds();
            InitializePlayers();
        }

        #endregion
       
        private void LoadSettings() =>
            _settings = ResourcesLoader.LoadResource<UnityAdsSettings>(_settingsPath);

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