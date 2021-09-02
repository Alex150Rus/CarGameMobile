using System;

namespace Tools
{
    internal interface IReadOnlySubscriptionAction
    {
        void SubscribeOnChange(Action subscriptionAction);
        void UnSubscribeOnChange(Action subscriptionAction);
    }
}