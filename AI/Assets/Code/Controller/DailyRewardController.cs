using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyRewardController 
{
    private DailyRewardView _dailyRewardView;
    private List<ContainerSlotRewardView> _slots;
    private bool _isGetReward;

    public DailyRewardController(DailyRewardView dailyRewardView)
    {
        _dailyRewardView = dailyRewardView;
    }

    public void RefreshView()
    {
        InitSlots();
        _dailyRewardView.StartCoroutine(RewardsStateUpdate());

        RefreshUi();
        SubscribeButtons();
    }

    private void InitSlots()
    {
        _slots = new List<ContainerSlotRewardView>();

        for(int i = 0; i < _dailyRewardView.Rewards.Count; i++)
        {
            var instanceSlot = GameObject.Instantiate(_dailyRewardView.ContainerSlot,
                    _dailyRewardView.MountRootSlotsReward, false);
            
            _slots.Add(instanceSlot);
        }
    }

    private IEnumerator RewardsStateUpdate()
    {
        while(true)
        {
            RefreshRewardsState();
            yield return new WaitForSeconds(1);
        }
    }

    private void RefreshRewardsState()
    {
        _isGetReward = true;

        if(_dailyRewardView.TimeGetReward.HasValue)
        {
            var timeSpan = DateTime.UtcNow - _dailyRewardView.TimeGetReward.Value;

            if(timeSpan.Seconds > _dailyRewardView.TimeDeadline)
            {
                _dailyRewardView.TimeGetReward = null;
                _dailyRewardView.CurrentSlotActive = 0;
            }
            else if(timeSpan.Seconds < _dailyRewardView.TimeCoolDown)
            {
                _isGetReward = false;
            }
        }

        RefreshUi();
    }

    private void RefreshUi()
    {
        _dailyRewardView.GetRewardButton.interactable = _isGetReward;

        if(_isGetReward)
        {
            _dailyRewardView.Timer.text = "GET REWARD NOW!!!";
        }
        else
        {
            if(_dailyRewardView.TimeGetReward != null)
            {
                var nextClaimTime = _dailyRewardView.TimeGetReward.Value.AddSeconds(_dailyRewardView.TimeCoolDown);
                var currentClaimCooldown = nextClaimTime - DateTime.UtcNow;
                var timeGetReward = $"{currentClaimCooldown.Days:D2}:{currentClaimCooldown.Hours:D2}:{currentClaimCooldown.Minutes:D2}:{currentClaimCooldown.Seconds:D2}";

                _dailyRewardView.Timer.text = $"Time to get the reward: {timeGetReward}";
            }
        }

        for(int i = 0; i < _slots.Count; i++)
        {
            _slots[i].SetDate(_dailyRewardView.Rewards[i], i + 1, i == _dailyRewardView.CurrentSlotActive);
        }
    }

    private void SubscribeButtons()
    {
        _dailyRewardView.GetRewardButton.onClick.AddListener(CLaimReward);
        _dailyRewardView.ResetButton.onClick.AddListener(ResetAll);
    }

    private void CLaimReward()
    {
        if (!_isGetReward) return;

        var reward = _dailyRewardView.Rewards[_dailyRewardView.CurrentSlotActive];

        if (reward.Rewardtype == RewardType.Molot)
        {
            CurrencyView.Instance.AddMolot(reward.CountResource);
        }

        if (reward.Rewardtype == RewardType.Tree)
        {
            CurrencyView.Instance.AddTree(reward.CountResource);
        }

        _dailyRewardView.TimeGetReward = DateTime.UtcNow;
        _dailyRewardView.CurrentSlotActive = (_dailyRewardView.CurrentSlotActive + 1) % _dailyRewardView.Rewards.Count;

        RefreshRewardsState();
    }

    private void ResetAll()
    {
        PlayerPrefs.DeleteAll();
    }
}
