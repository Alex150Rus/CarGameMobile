using System;
using Datas;
using Profile;
using Services.Ads.UnityAds;
using Services.Analytics;
using UnityEngine;
using UnityEngine.Events;

internal sealed class EntryPoint: MonoBehaviour
{
    [SerializeField] private Transform _placeForUI;
    [SerializeField] private PlayerData _data;
    [SerializeField] private AnalyticsManager _analytics;
    [SerializeField] private UnityAdsService _unityAdsService;

    private MainController _mainController;

    private void Awake()
    {
        var profilePlayer = new ProfilePlayer(_data, GameState.Start);
        _mainController = new MainController(_placeForUI, profilePlayer);
        
    }

    private void Start()
    {
        _analytics.SendMainMenuOpened();
        _unityAdsService.Initialized.AddListener(Play());
    }

    private void OnDestroy()
    {
        _mainController?.Dispose();
        _unityAdsService.Initialized.RemoveListener(Play());
    }

    private UnityAction Play()
    {
        return _unityAdsService.InterstitialPlayer.Play;
    }
}