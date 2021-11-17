using UnityEngine;
using UnityEngine.Advertisements;
public class ProfilePlayer 
{
    public SubscriptionProperty<GameState> CurrentState { get; }
    public Car CurrentCar { get; }
    //public IAnalyticTools AnalyticTools { get; }
    public IAdsShower AddShower { get; }
    public IUnityAdsListener UnityAddListener { get; }

    public ProfilePlayer(float speed, UnityAdsTools unityAdsTools) //, IAnalyticTools analyticTools
    {
        CurrentState = new SubscriptionProperty<GameState>();
        CurrentCar = new Car(speed);
        //AnalyticTools = analyticTools;
        AddShower = unityAdsTools;
        UnityAddListener = unityAdsTools;
    }
}

public enum GameState
{
    Start,
    Game
}
