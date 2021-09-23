using Infrastructure.Ads.UnityAds;
using Profile;
using Services.Ads.UnityAds;
using Services.Analytics;
using Services.Shop;
using Tools;
using UnityEngine;

namespace Ui
{
    internal sealed class MainMenuController: BaseViewController
    {
        private readonly MainMenuView _view;
        private readonly ProfilePlayer _profilePlayer;
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/MainMenu");
        private readonly RewardedPlayerLauncher _rewardedPlayerLauncher = new RewardedPlayerLauncher(); 

        public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView<MainMenuView>(placeForUi, _resourcePath);
            _view.Init(StartGame, GoToSettings, _rewardedPlayerLauncher.LaunchRewardAd, RemoveAds, GoToShed);
        }

        private void StartGame() => _profilePlayer.CurrentState.Value = GameState.Game;
        private void GoToSettings() => _profilePlayer.CurrentState.Value = GameState.Settings;

        private void GoToShed()
        {
            _profilePlayer.CurrentState.Value = GameState.Shed;
        }

        private void RemoveAds()
        {
            Infrastructure.Services.Shop.Buy(ProductNamesManager.PRODUCT_REMOVE_ADS);
        }
    }
}