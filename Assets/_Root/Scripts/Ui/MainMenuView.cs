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
        private UnityAction _startGame;
        private UnityAction _goToSettings;
        private UnityAction _showRewardAd;

        public void Init(UnityAction startGame, UnityAction goToSettings, UnityAction showRewardAd)
        {
            _startGame = startGame;
            _goToSettings = goToSettings;
            _showRewardAd = showRewardAd;
            _buttonStart.onClick.AddListener(_startGame);
            _buttonSettings.onClick.AddListener(_goToSettings);
            _buttonShowRewardAd.onClick.AddListener(_showRewardAd);
        }

        public void OnDestroy()
        {
            _buttonStart.onClick.RemoveListener(_startGame);
            _buttonSettings.onClick.RemoveListener(_goToSettings);
            _buttonShowRewardAd.onClick.RemoveListener(_showRewardAd);
        }
    }
}