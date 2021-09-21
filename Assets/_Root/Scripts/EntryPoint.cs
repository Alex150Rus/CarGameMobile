using System;
using System.Collections.Generic;
using Datas;
using Profile;
using Services.Ads.UnityAds;
using Services.Analytics;
using Services.Shop;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Purchasing;

internal sealed class EntryPoint: MonoBehaviour
{
    [SerializeField] private Transform _placeForUI;
    [SerializeField] private PlayerData _data;
    [SerializeField] private ShopProductsData _shopProducts;

    private MainController _mainController;

    private void Awake()
    {
        var shop = new ShopTools(_shopProducts.ShopProducts);
        var profilePlayer = new ProfilePlayer(_data, GameState.Start, shop);
        _mainController = new MainController(_placeForUI, profilePlayer);
        UnityAdsService.Instance.Initialized.AddListener(Play());
        
    }

    private void Start()
    {
        AnalyticsManager.Instance.SendMainMenuOpened();
    }

    private void OnDestroy()
    {
        _mainController?.Dispose();
        UnityAdsService.Instance.Initialized.RemoveListener(Play());
    }

    private UnityAction Play()
    {
        return UnityAdsService.Instance.InterstitialPlayer.Play;
    }
}