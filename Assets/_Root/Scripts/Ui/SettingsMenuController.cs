using Profile;
using Tools;
using UnityEngine;

namespace Ui
{
    internal class SettingsMenuController: BaseViewController
    {
        private readonly SettingsMenuView _view;
        private readonly ProfilePlayer _profilePlayer;
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/settingsMenu");

        public SettingsMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView<SettingsMenuView>(placeForUi, _resourcePath);
            _view.Init(Back);
        }

        private void Back() => _profilePlayer.CurrentState.Value = GameState.Start;
    }
}