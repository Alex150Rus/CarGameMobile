using Datas;
using Datas.Shed;
using Inventory;
using Profile;
using UnityEngine;
using UnityEngine.Events;

internal sealed class EntryPoint: MonoBehaviour
{
    [Header("Configs")]
    [SerializeField] private InventoryModelConfig _inventoryModelConfig;
    [SerializeField] private UpgradeItemConfigDataSource _upgradeItemConfig; 
   [SerializeField] private PlayerData _data;
    
    [Header("Components")]
    [SerializeField] private Transform _placeForUI;

    private MainController _mainController;

    private void Awake()
    {
        var profilePlayer = CreateProfilePlayer(_data);
        InitializeInventoryModel(_inventoryModelConfig, profilePlayer.Inventory);
        _mainController = new MainController(_placeForUI, profilePlayer, _upgradeItemConfig.ItemConfigs);
        Infrastructure.Services.Analytics.SendMainMenuOpened();
        Infrastructure.Services.Ads.Initialized.AddListener(PlayInterstitialAd());
    }

    private ProfilePlayer CreateProfilePlayer(PlayerData playerData)
    {
        return new ProfilePlayer(_data, GameState.Start);
    }

    private UnityAction PlayInterstitialAd()
    {
        Infrastructure.Services.Ads.InterstitialPlayer.Skipped += OnSkippedAd;
        return Infrastructure.Services.Ads.InterstitialPlayer.Play;
    }

    private void OnSkippedAd()
    {
        Debug.Log("Skipped when started");
        Infrastructure.Services.Analytics.SendInterstitialAddSkipped();
        Infrastructure.Services.Ads.InterstitialPlayer.Skipped -= OnSkippedAd;
    }

    private void InitializeInventoryModel(InventoryModelConfig inventoryModelConfig, InventoryModel inventoryModel)
    {
        var initializer = new InventoryInitializer(inventoryModelConfig);
        initializer.InitializeModel(inventoryModel);
    }
    
    private void OnDestroy()
    {
        _mainController?.Dispose();
        Infrastructure.Services.Ads.Initialized.RemoveListener(PlayInterstitialAd());
    }
}