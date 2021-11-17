using UnityEngine;
using UnityEngine.Advertisements;

public class MainMenuController : BaseController
{
    private MainMenuView _menuView;
    private readonly ProfilePlayer _profilePlayer;
    private readonly ResurcePath _viewPath = new ResurcePath {PathResurce = "Prefabs/mainMenu"};

    public MainMenuController(ProfilePlayer profilePlayer)
    {
        _profilePlayer = profilePlayer;
        _menuView = LoadView();
        _menuView.GetButtonStartGame.onClick.AddListener(StartGame);
        _profilePlayer.AddShower.ShowInterstitial();
        Advertisement.AddListener(_profilePlayer.UnityAddListener);
    }

    private MainMenuView LoadView()
    {
        //GameObject objectView = Object.Instantiate(ResurceLoader.LoadPrefab(_viewPath), placeUI, false);
        //AddGameObject(objectView);
        return GameObject.FindObjectOfType<MainMenuView>(); //objectView.GetComponent<MainMenuView>();
    }

    private void StartGame()
    {
        _profilePlayer.CurrentState.Value = GameState.Game;
        _menuView.GetButtonStartGame.gameObject.SetActive(false);
        Debug.Log("Игра началась");
        //_profilePlayer.AnalyticTools.SendMassage("start_game");
    }
}
