using System;

namespace Tools
{
    internal interface ISubscriptionProperty<out TValue>
    {
        public TValue Value { get; }
        public void SubscribeOnChange(Action<TValue> subscriptionAction);
        public void UnSubscribeOnChange(Action<TValue> unsubscriptionAction);


    }
}