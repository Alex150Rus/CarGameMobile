using System;

namespace Tools
{
    internal sealed class SubscriptionProperty<TValue> : ISubscriptionProperty<TValue>
    {
        private TValue _prevValue;
        private TValue _value;
        private Action<TValue> _onChangeValue;

        public TValue Value
        {
            get => _value;
            set
            {
                _prevValue = _value;
                _value = value;
                _onChangeValue?.Invoke(_value);
            }
        }

        public TValue PreviousValue => _prevValue;

        public void SubscribeOnChange(Action<TValue> subscriptionAction) =>
            _onChangeValue += subscriptionAction;

        public void UnSubscribeOnChange(Action<TValue> unsubscriptionAction) =>
            _onChangeValue -= unsubscriptionAction;
    }
}