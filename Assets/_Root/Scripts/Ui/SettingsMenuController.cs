using Profile;
using Tools;
using UnityEngine;

namespace Ui
{
    internal class SettingsMenuController: BaseController
    {
        private readonly SettingsMenuView _view;
        private readonly ProfilePlayer _profilePlayer;
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/settingsMenu");

        public SettingsMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUi);
            _view.Init(Back);
        }

        private SettingsMenuView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadResource<GameObject>(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<SettingsMenuView>();
        }

        private void Back() => _profilePlayer.CurrentState.Value = GameState.Start;
    }
}