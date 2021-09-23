using System;
using System.Collections;
using UnityEngine;

namespace Infrastructure.Ads.UnityAds
{
    internal class RewardedPlayerLauncher {

        public event Action Finished;
        public void LaunchRewardAd()
        {
            SubscribeRewardedPlayerEvents();
            Services.Ads.RewardedPlayer.Play();
        }

        private void SubscribeRewardedPlayerEvents()
        {
            Services.Ads.RewardedPlayer.Finished += OnRewardedPlayerFinished;
            Services.Ads.RewardedPlayer.Failed += OnRewardedPlayerFailed;
            Services.Ads.RewardedPlayer.Skipped += OnRewardedAddSkipped;
        }

        private void OnRewardedPlayerFinished()
        {

            Finished?.Invoke();
            UnSubscribeRewardedPlayerEvents();
        }

        private void OnRewardedPlayerFailed()
        {
            UnSubscribeRewardedPlayerEvents();
        }

        private void OnRewardedAddSkipped()
        {
            UnSubscribeRewardedPlayerEvents();
            Services.Analytics.SendRewardedAddSkipped();
        }
        private void UnSubscribeRewardedPlayerEvents()
        {
            Services.Ads.RewardedPlayer.Finished -= OnRewardedPlayerFinished;
            Services.Ads.RewardedPlayer.Failed -= OnRewardedPlayerFailed;
            Services.Ads.RewardedPlayer.Skipped -= OnRewardedAddSkipped;
        }
    }
}