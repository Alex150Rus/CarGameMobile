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
        switch (state)
        {
            case GameState.Start:
                DisposeAllControllers();
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                break;
            case GameState.Game:
                DisposeAllControllers();
                _gameController = new GameController(_profilePlayer);
                break;
            case GameState.Settings:
                DisposeAllControllers();
                _settingsMenuController = new SettingsMenuController(_placeForUi, _profilePlayer);
                break;
            case GameState.Shed:
                DisposeAllControllers();
                if(_shedController == null)
                    _shedController = new ShedController(_profilePlayer,
                    _upgradeItemConfig, _placeForUi);
                else
                {
                    _shedController.Enter();
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(GameState));
        }
    }

    private void DisposeAllControllers()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _settingsMenuController?.Dispose();
    }

    protected override void OnDisposed()
    {
        DisposeAllControllers();
        _shedController?.Dispose();
        _profilePlayer.CurrentState.UnSubscribeOnChange(OnChangeGameState);
    }
}