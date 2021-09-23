using System;
using System.Collections.Generic;
using System.Linq;
using Datas.Shed;
using Game.Transport;
using Inventory;
using Inventory.Items;
using JetBrains.Annotations;
using Profile;
using Shed.UpgradeHandlers;
using Tools;
using UnityEngine;

namespace Shed
{
    internal interface IShedController
    {
        void Enter();
        void Exit();
    }
    
    internal class ShedController: BaseViewController, IShedController
    {
        private readonly TransportModel _transport;

        private readonly UpgradeHandlersRepository _upgradeHandlersRepository;
        private readonly ItemsRepository _upgradeItemsRepository;
        private readonly InventoryModel _inventoryModel;
        private readonly InventoryController _inventoryController;
        private readonly Transform _placeForUi;
        private readonly ProfilePlayer _profilePlayer;
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/Shed/Shed");

        public ShedController(
            [NotNull] ProfilePlayer profilePlayer,
            [NotNull] IReadOnlyList<UpgradeItemConfig> upgradeItemConfigs,
            [NotNull] Transform placeForUi)
        {
            if (upgradeItemConfigs == null)
                throw new ArgumentNullException(nameof(upgradeItemConfigs));
            
            _profilePlayer = profilePlayer ?? throw new ArgumentNullException(nameof(profilePlayer));
            _transport = profilePlayer.CurrentTransport ?? throw new ArgumentNullException(nameof(_transport));
            _inventoryModel = profilePlayer.Inventory ?? throw new ArgumentNullException(nameof(_inventoryModel));
            _placeForUi = placeForUi ?? throw new ArgumentNullException();
            
            _upgradeHandlersRepository = new UpgradeHandlersRepository(upgradeItemConfigs);
            AddRepository(_upgradeHandlersRepository);

            _upgradeItemsRepository =
                new ItemsRepository(upgradeItemConfigs.Select(value => value.ItemConfig).ToList());
            AddRepository(_upgradeItemsRepository);
            
            _inventoryController = new InventoryController(_profilePlayer, _upgradeItemsRepository, _placeForUi);
            AddController(_inventoryController);
            
            Enter();
        }

        public void Enter()
        {
            LoadView<ShedView>(_placeForUi, _resourcePath);
            _inventoryController.ShowInventory(Exit);
            Debug.Log($"Enter: car has speed : {_transport.Speed}");
        }

        public void Exit()
        {
            UpgradeCarWithEquippedItems(_transport, _inventoryModel.GetEquippedItems(),
                _upgradeHandlersRepository.UpgradableItems);
            Debug.Log($"Exit: car has speed: {_transport.Speed}");
        }

        private void UpgradeCarWithEquippedItems(IUpgradeableTransport upgradableTransport, 
            IReadOnlyList<IItem> equippedItems, 
            IReadOnlyDictionary<int, IUpgradeTransportHandler> upgradeHandlers)
        {
            foreach (var equippedItem in equippedItems)
            {
                if (upgradeHandlers.TryGetValue(equippedItem.Id, out var handler))
                    handler.Upgrade(upgradableTransport);
            }
        }

        protected override void OnDisposed()
        {
            base.OnDisposed();
            _upgradeHandlersRepository?.Dispose();
            _upgradeItemsRepository?.Dispose();
            _inventoryController?.Dispose();
            
        }
    }
}