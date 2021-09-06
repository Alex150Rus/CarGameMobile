using System;
using System.Collections.Generic;
using Datas.Shed;
using Game;
using JetBrains.Annotations;
using Profile;
using Shed;
using Ui;
using UnityEngine;

internal sealed class MainController : BaseController
{
    private MainMenuController _mainMenuController;
    private GameController _gameController;
    private SettingsMenuController _settingsMenuController;
    private ShedController _shedController;
    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;
    private IReadOnlyList<UpgradeItemConfig> _upgradeItemConfig;

    public MainController(Transform placeForUi, ProfilePlayer profilePlayer, 
        IReadOnlyList<UpgradeItemConfig> upgradeItemConfig)
    {
        _placeForUi = placeForUi;
        _profilePlayer = profilePlayer;
        _upgradeItemConfig = upgradeItemConfig;
        _profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        OnChangeGameState(_profilePlayer.CurrentState.Value);
    }

    private void OnChangeGameState(GameState state)
    {
        DisposeAllControllers();
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                break;
            case GameState.Game:
                _gameController = new GameController(_profilePlayer);
                break;
            case GameState.Settings:
                _settingsMenuController = new SettingsMenuController(_placeForUi, _profilePlayer);
                break;
            case GameState.Shed:
                _shedController = new ShedController(_profilePlayer.Inventory, _profilePlayer.CurrentTransport,
                _upgradeItemConfig, _placeForUi);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(GameState));
                break;
        }
    }

    private void DisposeAllControllers()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _settingsMenuController?.Dispose();
        _shedController?.Dispose();
    }

    protected override void OnDisposed()
    {
        DisposeAllControllers();
        _profilePlayer.CurrentState.UnSubscribeOnChange(OnChangeGameState);
    }
}