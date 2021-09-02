using UnityEngine.Advertisements;

namespace Services.Ads.UnityAds
{
    internal class InterstitialPlayer: UnityAdsPlayer
    {
        public InterstitialPlayer(string id) : base(id)
        {
        }

        protected override void OnPlaying() => Advertisement.Show(_id);

        protected override void Load() => Advertisement.Load(_id);
    }
}