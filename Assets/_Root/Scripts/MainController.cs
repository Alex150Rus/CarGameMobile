using Game;
using Profile;
using Ui;
using UnityEngine;

internal sealed class MainController : BaseController
{
    private MainMenuController _mainMenuController;
    private GameController _gameController;
    private SettingsMenuController _settingsMenuController;
    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;

    public MainController(Transform placeForUi, ProfilePlayer profilePlayer)
    {
        _placeForUi = placeForUi;
        _profilePlayer = profilePlayer;
        _profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        OnChangeGameState(_profilePlayer.CurrentState.Value);
    }

    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                _gameController?.Dispose();
                _settingsMenuController?.Dispose();
                break;
            case GameState.Game:
                _gameController = new GameController(_profilePlayer);
                _mainMenuController?.Dispose();
                break;
            case GameState.Settings:
                _settingsMenuController = new SettingsMenuController(_placeForUi, _profilePlayer);
                _gameController?.Dispose();
                _mainMenuController?.Dispose();
                break;
            default:
                _mainMenuController?.Dispose();
                _gameController?.Dispose();
                _settingsMenuController?.Dispose();
                break;
        }
    }

    protected override void OnDisposed()
    {
        _mainMenuController?.Dispose();
        _gameController?.Dispose();

        _profilePlayer.CurrentState.UnSubscribeOnChange(OnChangeGameState);
    }
}