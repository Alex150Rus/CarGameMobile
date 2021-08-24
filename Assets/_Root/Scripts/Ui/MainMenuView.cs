using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    internal class MainMenuView : MonoBehaviour
    {
        [SerializeField] private Button _buttonStart;
        private UnityAction _startGame;

        public void Init(UnityAction startGame)
        {
            _startGame = startGame;
            _buttonStart.onClick.AddListener(startGame);   
        }

        public void OnDestroy() => _buttonStart.onClick.RemoveListener(_startGame);
    }
}