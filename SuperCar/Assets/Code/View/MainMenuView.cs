using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button _buttonStart;

    public void Init(UnityAction startGame)
    {
        _buttonStart.onClick.AddListener(startGame);
    }

    protected void OnDestroy()
    {
        _buttonStart.onClick.RemoveAllListeners();
    }
}
