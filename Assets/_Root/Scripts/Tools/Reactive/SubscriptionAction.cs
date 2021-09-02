using System;

namespace Tools
{
    public class SubscriptionAction : IReadOnlySubscriptionAction
    {
        private Action _action;

        public void Invoke() =>
            _action?.Invoke();

        public void SubscribeOnChange(Action subscriptionAction) =>
            _action += subscriptionAction;

        public void UnSubscribeOnChange(Action unsubscriptionAction) =>
            _action -= unsubscriptionAction;
    }
}