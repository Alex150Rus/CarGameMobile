using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    internal class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Button _buttonShowRewardAd;
        [SerializeField] private Button _buttonSettings;
        [SerializeField] private Button _buttonRemoveAds;
        private UnityAction _startGame;
        private UnityAction _goToSettings;
        private UnityAction _showRewardAd;
        private UnityAction _removeAds;

        public void Init(UnityAction startGame, UnityAction goToSettings, UnityAction showRewardAd,
            UnityAction removeAds)
        {
            _startGame = startGame;
            _goToSettings = goToSettings;
            _showRewardAd = showRewardAd;
            _removeAds = removeAds;
            _buttonStart.onClick.AddListener(_startGame);
            _buttonSettings.onClick.AddListener(_goToSettings);
            _buttonShowRewardAd.onClick.AddListener(_showRewardAd);
            _buttonRemoveAds.onClick.AddListener(_removeAds);
        }

        public void OnDestroy()
        {
            _buttonStart.onClick.RemoveListener(_startGame);
            _buttonSettings.onClick.RemoveListener(_goToSettings);
            _buttonShowRewardAd.onClick.RemoveListener(_showRewardAd);
            _buttonRemoveAds.onClick.RemoveListener(_removeAds);
        }
    }
}