using System;
using Tools;
using UnityEngine;

namespace Game.TapeBackground
{
    internal sealed class TapeBackgroundView : MonoBehaviour
    {
        [SerializeField] private Background[] _backgrounds;

        private SubscriptionProperty<float> _diff;

        public void Init(SubscriptionProperty<float> diff)
        {
            _diff = diff;
            _diff.SubscribeOnChange(Move);
        }

        private void Move(float value)
        {
            foreach (Background background in _backgrounds)
            {
                background.Move(-value);
            }
        }

        private void OnDestroy()
        {
            _diff?.UnSubscribeOnChange(Move);
        }
    }
}