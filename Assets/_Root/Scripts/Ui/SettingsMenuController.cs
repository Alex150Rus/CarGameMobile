using Profile;
using Tools;
using UnityEngine;

namespace Ui
{
    internal class SettingsMenuController: BaseViewController
    {
        private readonly SettingsMenuView _view;
        private readonly ProfilePlayer _profilePlayer;

        public SettingsMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            ResourcePath = new ResourcePath("Prefabs/settingsMenu");
            Parent = placeForUi;
            _profilePlayer = profilePlayer;
            _view = LoadView<SettingsMenuView>();
            _view.Init(Back);
        }

        private void Back() => _profilePlayer.CurrentState.Value = GameState.Start;
    }
}