using System;
using Datas;
using Profile;
using Services.Analytics;
using UnityEngine;

internal sealed class EntryPoint: MonoBehaviour
{
    [SerializeField] private Transform _placeForUI;
    [SerializeField] private PlayerData _data;
    [SerializeField] private AnalyticsManager _analytics;

    private MainController _mainController;

    private void Awake()
    {
        var profilePlayer = new ProfilePlayer(_data, GameState.Start);
        _mainController = new MainController(_placeForUI, profilePlayer);
    }

    private void Start()
    {
        _analytics.SendMainMenuOpened();
    }

    private void OnDestroy()
    {
        _mainController?.Dispose();
    }
}