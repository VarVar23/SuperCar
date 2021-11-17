using System.Collections.Generic;
public interface IAnalyticTools 
{
    void SendMassage(string alias, IDictionary<string, object> eventData = null);
}
