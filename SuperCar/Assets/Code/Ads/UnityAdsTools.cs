using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsTools : MonoBehaviour, IAdsShower, IUnityAdsListener
{
    [SerializeField] private MainMenuView _mainMenuView;

    private string _gameId = "111111";
    private string _rewardPlace = "rewardAds";
    private string _interstitialPlace = "Interstitial_Android";

    private Action _callbackSuccessShowVideo;

    private void Start()
    {
        Advertisement.Initialize(_gameId, true);
        _mainMenuView.GetButtonStartGame.onClick.AddListener(ShowInterstitial);
    }

    public void OnUnityAdsDidError(string message)
    {

    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
            _callbackSuccessShowVideo?.Invoke();
    }

    public void OnUnityAdsDidStart(string placementId)
    {

    }

    public void OnUnityAdsReady(string placementId)
    {

    }

    public void ShowInterstitial()
    {
        _callbackSuccessShowVideo = null;
        Advertisement.Show(_interstitialPlace);
    }

    public void ShowVideo(Action succesShow)
    {
        _callbackSuccessShowVideo = succesShow;
        Advertisement.Show(_rewardPlace);
    }
}
