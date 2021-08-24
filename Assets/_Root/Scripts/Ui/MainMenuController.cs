using Profile;
using Tools;
using UnityEngine;

namespace Ui
{
    internal sealed class MainMenuController: BaseController
    {
        private readonly MainMenuView _view;
        private readonly ProfilePlayer _profilePlayer;
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/MainMenu");

        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(StartGame);
        }

        private MainMenuView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<MainMenuView>();
        }

        private void StartGame() => _profilePlayer.CurrentState.Value = GameState.Game;
    }
}