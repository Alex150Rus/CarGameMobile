using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Infrastructure.Ads.UnityAds
{
    internal class InterstitialAdLauncher
    {

        private UnityEvent _adsInitialized;

        public void Launch()
        {
            _adsInitialized = Infrastructure.Services.Ads.Initialized;
            _adsInitialized.AddListener(PlayInterstitialAd());
        }

        private UnityAction PlayInterstitialAd()
        {
            Services.Ads.InterstitialPlayer.Skipped += OnSkippedAd;
            Services.Ads.InterstitialPlayer.Failed += OnFailedAd;
            Services.Ads.InterstitialPlayer.Finished += OnFinishedAd;
            return Services.Ads.InterstitialPlayer.Play;
        }

        private void OnFinishedAd()
        {
            UnsubscribeInterstitialPlayerEvents();
        }

        private void OnFailedAd()
        {
            UnsubscribeInterstitialPlayerEvents();
        }

        private void UnsubscribeInterstitialPlayerEvents()
        {
            Services.Ads.InterstitialPlayer.Skipped -= OnSkippedAd;
            Services.Ads.InterstitialPlayer.Failed -= OnFailedAd;
            Services.Ads.InterstitialPlayer.Finished -= OnFinishedAd;
            _adsInitialized.RemoveListener(PlayInterstitialAd());
        }

        private void OnSkippedAd()
        {
            Debug.Log("Skipped when started");
            Services.Analytics.SendInterstitialAddSkipped();
            UnsubscribeInterstitialPlayerEvents();
        }
    }
}