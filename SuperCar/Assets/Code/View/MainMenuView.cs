using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button _buttonStart;
    public Button GetButtonStartGame => _buttonStart;

    protected void OnDestroy()
    {
        _buttonStart.onClick.RemoveAllListeners();
    }
}
