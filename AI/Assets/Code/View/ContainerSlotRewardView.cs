using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContainerSlotRewardView : MonoBehaviour
{
    [SerializeField] private Image _selectBackround;
    [SerializeField] private Image _iconCurrently;
    [SerializeField] private TMP_Text _textDay;
    [SerializeField] private TMP_Text _countReward;

    public void SetDate(Reward reward, int countDay, bool isSelect)
    {
        _iconCurrently.sprite = reward.IconResource;
        _textDay.text = $"Day: {countDay}";
        _countReward.text = reward.CountResource.ToString();
        _selectBackround.gameObject.SetActive(isSelect);
    }
}
