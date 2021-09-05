using System;
using System.Collections.Generic;
using Datas;
using Inventory;
using Profile;
using Services.Ads.UnityAds;
using Services.Analytics;
using Services.Shop;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Purchasing;

internal sealed class EntryPoint: MonoBehaviour
{
    [Header("Configs")]
    [SerializeField] private InventoryModelConfig _inventoryModelConfig;
    [SerializeField] private ShopProductsData _shopProducts;
    [SerializeField] private PlayerData _data;
    
    [Header("Components")]
    [SerializeField] private Transform _placeForUI;
    
    

    private MainController _mainController;

    private void Awake()
    {
        var shop = new ShopTools(_shopProducts.ShopProducts);
        var profilePlayer = new ProfilePlayer(_data, GameState.Start, shop);
        InitializeInventoryModel(_inventoryModelConfig, profilePlayer.Inventory);
        _mainController = new MainController(_placeForUI, profilePlayer);
        UnityAdsService.Instance.Initialized.AddListener(Play());
        
    }

    private void Start()
    {
        AnalyticsManager.Instance.SendMainMenuOpened();
    }

    private UnityAction Play()
    {
        return UnityAdsService.Instance.InterstitialPlayer.Play;
    }

    private void InitializeInventoryModel(InventoryModelConfig inventoryModelConfig, InventoryModel inventoryModel)
    {
        var initializer = new InventoryInitializer(inventoryModelConfig);
        initializer.InitializeModel(inventoryModel);
    }
    
    private void OnDestroy()
    {
        _mainController?.Dispose();
        UnityAdsService.Instance.Initialized.RemoveListener(Play());
    }
}