using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    internal class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Button _buttonSettings;
        private UnityAction _startGame;
        private UnityAction _goToSettings;

        public void Init(UnityAction startGame, UnityAction goToSettings)
        {
            _startGame = startGame;
            _goToSettings = goToSettings;
            _buttonStart.onClick.AddListener(startGame);
            _buttonSettings.onClick.AddListener(goToSettings);
        }

        public void OnDestroy()
        {
            _buttonStart.onClick.RemoveListener(_startGame);
            _buttonSettings.onClick.RemoveListener(_goToSettings);
        }
    }
}