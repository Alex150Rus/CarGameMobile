using System;
using System.Diagnostics;
using Tools.Logger;
using UnityEngine;
using UnityEngine.Advertisements;
using Debug = UnityEngine.Debug;
using ILogger = Tools.Logger.ILogger;

namespace Services.Ads.UnityAds
{
    internal abstract class UnityAdsPlayer: IAdsPlayer, IUnityAdsListener
    {
        public event Action Started;
        public event Action Finished;
        public event Action Failed;
        public event Action Skipped;
        public event Action BecomeReady;

        protected readonly string _id;
        protected ILogger _logger;
        
        protected UnityAdsPlayer(string id)
        {
            _id = id;
            _logger = new DebugLogger();
        }
        
        public void Play()
        {
            Load();
            OnPlaying();
            Load();
        }

        protected abstract void OnPlaying();

        protected abstract void Load();

        public void OnUnityAdsReady(string placementId)
        {
            if (IsIdMy(placementId) == false)
                return;
            Log("Ready");
        }

        private bool IsIdMy(string placementId) => _id == placementId;

        public void OnUnityAdsDidError(string message)
        {
            Log($"Error: {message}");
            BecomeReady?.Invoke();
        }

        public void OnUnityAdsDidStart(string placementId)
        {
            if (IsIdMy(placementId) == false)
                return;
            Log("Started");
            Started?.Invoke();
        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            if (IsIdMy(placementId) == false)
                return;
            switch (showResult)
            {
                case ShowResult.Finished:
                    Log("Finished");
                    Finished?.Invoke();
                    break;
                case ShowResult.Failed:
                    Log("Failed");
                    Failed?.Invoke();
                    break;
                case ShowResult.Skipped:
                    Log("Skipped");
                    Skipped?.Invoke();
                    break;
            }
        }

        private void Log(string message) =>
            _logger.Log($"[{GetType().Name}] [{_id}] {message}");
    }
}