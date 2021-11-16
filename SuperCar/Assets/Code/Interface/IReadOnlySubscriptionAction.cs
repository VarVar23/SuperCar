using System;

public interface IReadOnlySubscriptionAction 
{
    void SubscribeOnChange(Action subscriptionAction);
    void UnSubscribeOnChange(Action unsubscriptionAction);
}
