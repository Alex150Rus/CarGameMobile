using Datas;
using Datas.Shed;
using Infrastructure.Ads.UnityAds;
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
    private InterstitialAdLauncher _interstitialAdLauncher = new InterstitialAdLauncher();

    private void Awake()
    {
        var profilePlayer = CreateProfilePlayer(_data);
        InitializeInventoryModel(_inventoryModelConfig, profilePlayer.Inventory);
        _mainController = new MainController(_placeForUI, profilePlayer, _upgradeItemConfig.ItemConfigs);        
    }

    private void Start()
    {
        Infrastructure.Services.Analytics.SendMainMenuOpened();
        _interstitialAdLauncher.Launch();
    }

    private ProfilePlayer CreateProfilePlayer(PlayerData playerData)
    {
        return new ProfilePlayer(_data, GameState.Start);
    }

    private void InitializeInventoryModel(InventoryModelConfig inventoryModelConfig, InventoryModel inventoryModel)
    {
        var initializer = new InventoryInitializer(inventoryModelConfig);
        initializer.InitializeModel(inventoryModel);
    }
    
    private void OnDestroy()
    {        
        _mainController?.Dispose();
    }
}