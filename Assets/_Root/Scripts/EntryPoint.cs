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

    private MainController _mainController;

    private void Awake()
    {
        var profilePlayer = new ProfilePlayer(_data, GameState.Start);
        _mainController = new MainController(_placeForUI, profilePlayer);
        UnityAdsService.Instance.Initialized.AddListener(Play());
        
    }

    private void Start()
    {
        AnalyticsManager.Instance.SendMainMenuOpened();
    }

    private void OnDestroy()
    {
        _mainController?.Dispose();
        UnityAdsService.Instance.Initialized.RemoveListener(Play());
    }

    private UnityAction Play()
    {
        return UnityAdsService.Instance.InterstitialPlayer.Play;
    }
}