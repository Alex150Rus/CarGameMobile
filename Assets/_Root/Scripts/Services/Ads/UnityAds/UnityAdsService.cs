using Services.Ads.UnityAds.Settings;
using Tools.Logger;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;

namespace Services.Ads.UnityAds
{
    internal class UnityAdsService: MonoBehaviour, IAdsService, IUnityAdsInitializationListener
    {
        [Header("Components")] [SerializeField]
        private UnityAdsSettings _settings;
        
        [field: Header("Events")]
        [field: SerializeField] public UnityEvent Initialized { get; private set; }

        private DebugLogger _logger;
        
        public IAdsPlayer InterstitialPlayer { get; private set; }
        public IAdsPlayer RewardedPlayer { get; private set; }
        public IAdsPlayer BannerPlayer { get; private set; }

        private void Awake()
        {
            InitializeAds();
            InitializePlayers();
            _logger = new DebugLogger();
        }

        private void InitializePlayers()
        {
            InterstitialPlayer = CreateInterstitial();
            RewardedPlayer = CreateRewarded();
            BannerPlayer = CreateBanner();

        }

        private IAdsPlayer CreateBanner() => new EmptyPlayer("");

        private IAdsPlayer CreateRewarded() => new EmptyPlayer("");

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