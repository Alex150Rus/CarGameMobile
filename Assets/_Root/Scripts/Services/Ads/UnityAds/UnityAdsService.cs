using System;
using System.Threading;
using Services.Ads.UnityAds.Settings;
using Tools;
using Tools.Logger;
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

        private DebugLogger _logger;
        
        public IAdsPlayer InterstitialPlayer { get; private set; }
        public IAdsPlayer RewardedPlayer { get; private set; }
        public IAdsPlayer BannerPlayer { get; private set; }

        #region Singlton pattern

        private static readonly Lazy<UnityAdsService> _instance = 
            new Lazy<UnityAdsService>(() => new UnityAdsService(), LazyThreadSafetyMode.ExecutionAndPublication);
        
        public static UnityAdsService Instance => _instance.Value;
        
        private UnityAdsService()
        {
            LoadSettings();
            InitializeAds();
            InitializePlayers();
            _logger = new DebugLogger();
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

        private IAdsPlayer CreateBanner() => new EmptyPlayer("");

        private IAdsPlayer CreateRewarded() => _settings.Rewarded.Enabled
            ? new RewardedPlayer(_settings.Rewarded.Id)
            : (IAdsPlayer) new EmptyPlayer("");

        private IAdsPlayer CreateInterstitial() => _settings.Interstitial.Enabled
            ? new InterstitialPlayer(_settings.Interstitial.Id)
            : (IAdsPlayer) new EmptyPlayer("");

        private void InitializeAds() => Advertisement.Initialize(
            _settings.GameId, 
            _settings.TestMode,
            _settings.EnablePerPlacementMode,
            this
            );


        public void OnInitializationComplete()
        {
            _logger.Log("Unity Ads Initialization complete.");
           Initialized?.Invoke();
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            _logger.Log($"Unity Ads Initialization Filed: {error.ToString()} - {message}.");
        }
    }
}