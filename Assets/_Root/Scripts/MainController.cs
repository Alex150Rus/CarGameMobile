using Profile;
using UnityEngine;

internal sealed class MainController: BaseController
{
    private readonly MainMenuController _mainMenuController;
    private readonly GameController _gameController;
    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;

    public MainController(Transform placeForUi, ProfilePlayer profilePlayer)
    {
        _mainMenuController = new MainMenuController();
        _gameController = new GameController();
        _placeForUi = placeForUi;
        _profilePlayer = profilePlayer;
    }
}