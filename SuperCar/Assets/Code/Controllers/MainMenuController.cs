using UnityEngine;

public class MainMenuController : BaseController
{
    private MainMenuView _menuView;
    private readonly ProfilePlayer _profilePlayer;
    private readonly ResurcePath _viewPath = new ResurcePath {PathResurce = "Prefabs/mainMenu"};

    public MainMenuController(Transform placeUI, ProfilePlayer profilePlayer)
    {
        _profilePlayer = profilePlayer;
        _menuView = LoadView(placeUI);
    }

    private MainMenuView LoadView(Transform placeUI)
    {
        GameObject objectView = Object.Instantiate(ResurceLoader.LoadPrefab(_viewPath), placeUI, false);
        AddGameObject(objectView);
        return objectView.GetComponent<MainMenuView>();
    }

    private void StartGame()
    {
        _profilePlayer.CurrentState.Value = GameState.Game;
        _profilePlayer.AnalyticTools.SendMassage("start_game");
    }
}
