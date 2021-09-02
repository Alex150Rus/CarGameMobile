using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui
{
    internal class SettingsMenuView: MonoBehaviour
    {
        [SerializeField] private Button _buttonBack;
        private UnityAction _back;

        public void Init(UnityAction back)
        {
            _back = back;
            _buttonBack.onClick.AddListener(back);
        }

        public void OnDestroy()
        {
            _buttonBack.onClick.RemoveListener(_back);
        }
    }
}