using UnityEngine;

public class ProfilePlayer 
{
    public SubscriptionProperty<GameState> CurrentState { get; }
    public Car CurrentCar { get; }
    //public IAnalyticTools AnalyticTools { get; }

    public ProfilePlayer(float speed) //, IAnalyticTools analyticTools
    {
        CurrentState = new SubscriptionProperty<GameState>();
        CurrentCar = new Car(speed);
        //AnalyticTools = analyticTools;
    }
}

public enum GameState
{
    Start,
    Game
}
