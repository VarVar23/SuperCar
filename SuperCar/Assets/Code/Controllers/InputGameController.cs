using UnityEngine;

public class InputGameController : BaseController
{
    private readonly ResurcePath _path = new ResurcePath { PathResurce = "" };
    private BaseInputView _inputView;

    public InputGameController(SubscriptionProperty<float> rightMove, SubscriptionProperty<float> leftMove, Car car)
    {
        _inputView = LoadView();
        _inputView.Init(leftMove, rightMove, car.Speed);
    }

    private BaseInputView LoadView()
    {
        GameObject realView = Object.Instantiate(ResurceLoader.LoadPrefab(_path));
        AddGameObject(realView);
        return realView.GetComponent<BaseInputView>();
    }
}
