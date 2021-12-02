using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System;

public class DailyRewardView : MonoBehaviour
{
    private const string CurrentSlotInActiveKey = nameof(CurrentSlotInActiveKey);
    private const string TimeGetRewardKey = nameof(TimeGetRewardKey);

    [Header("SettingTime")]
    [SerializeField] private int _timeCoolDown = 86400;
    [SerializeField] private int _timeDeadline = 172800;

    [SerializeField] private List<Reward> _rewards;

    [SerializeField] private TMP_Text _timer;
    [SerializeField] private Transform _mountRootSlotsReward;
    [SerializeField] private ContainerSlotRewardView _containerSlot;
    [SerializeField] private Button _getRewardButton;
    [SerializeField] private Button _resetButton;

    public Transform MountRootSlotsReward => _mountRootSlotsReward;
    public int TimeCoolDown => _timeCoolDown;
    public int TimeDeadline => _timeDeadline;
    public List<Reward> Rewards => _rewards;
    public TMP_Text Timer => _timer;
    public ContainerSlotRewardView ContainerSlot => _containerSlot;
    public Button GetRewardButton => _getRewardButton;
    public Button ResetButton => _resetButton;

    public int CurrentSlotActive
    {
        get => PlayerPrefs.GetInt(CurrentSlotInActiveKey, 0);
        set => PlayerPrefs.SetInt(CurrentSlotInActiveKey, value);
    }

    public DateTime ? TimeGetReward
    {
        get
        {
            var data = PlayerPrefs.GetString(TimeGetRewardKey, null);

            if (!string.IsNullOrEmpty(data)) return DateTime.Parse(data);

            return null;
        }
        set
        {
            if (value != null)
                PlayerPrefs.SetString(TimeGetRewardKey, value.ToString());
            else
                PlayerPrefs.DeleteKey(TimeGetRewardKey);
        }
    }

    private void OnDestroy()
    {
        _getRewardButton.onClick.RemoveAllListeners();
        _resetButton.onClick.RemoveAllListeners();
    }
}
