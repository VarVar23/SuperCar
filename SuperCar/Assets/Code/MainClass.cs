using UnityEngine;

public class MainClass : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private UnityAdsTools _unityAdsTools;

    private MainMenuController _mainMenuController;
    private ProfilePlayer _profilePlayer;

    private void Start()
    {
        _profilePlayer = new ProfilePlayer(_speed, _unityAdsTools);
        _mainMenuController = new MainMenuController(_profilePlayer);
    }
}
