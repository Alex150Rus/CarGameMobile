using Profile;
using Services.Ads.UnityAds;
using Services.Analytics;
using Services.Shop;
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
            _view.Init(StartGame, GoToSettings, ShowRewardAd, RemoveAds, GoToShed);
        }

        private MainMenuView LoadView(Transform placeForUi)
        {
            GameObject prefab = ResourcesLoader.LoadResource<GameObject>(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUi, false);
            AddGameObject(objectView);

            return objectView.GetComponent<MainMenuView>();
        }

        private void StartGame() => _profilePlayer.CurrentState.Value = GameState.Game;
        private void GoToSettings() => _profilePlayer.CurrentState.Value = GameState.Settings;

        private void GoToShed()
        {
            _profilePlayer.CurrentState.Value = GameState.Shed;
        }

        private void ShowRewardAd()
        {
            Infrastructure.Services.Ads.RewardedPlayer.Skipped += OnRewardedAddSkipped;
            Infrastructure.Services.Ads.RewardedPlayer.Play();
        }

        private void OnRewardedAddSkipped()
        {
            Infrastructure.Services.Analytics.SendRewardedAddSkipped();
            Infrastructure.Services.Ads.RewardedPlayer.Skipped -= OnRewardedAddSkipped;
        }

        private void RemoveAds()
        {
            Infrastructure.Services.Shop.Buy(ProductNamesManager.PRODUCT_REMOVE_ADS);
        }
    }
}