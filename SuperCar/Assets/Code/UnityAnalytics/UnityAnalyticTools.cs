
using System.Collections.Generic;
using UnityEngine.Analytics;

public class UnityAnalyticTools : IAnalyticTools
{
    public void SendMassage(string alias, IDictionary<string, object> eventData = null)
    {
        if (eventData == null) eventData = new Dictionary<string, object>();
        Analytics.CustomEvent(alias, eventData);
    }
}
