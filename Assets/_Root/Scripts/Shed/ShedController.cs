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
using UnityEngine;

namespace Shed
{
    internal interface IShedController
    {
        void Enter();
        void Exit();
    }
    
    internal class ShedController: RepositoryBaseController, IShedController
    {
        private readonly TransportModel _transport;

        private readonly UpgradeHandlersRepository _upgradeHandlersRepository;
        private readonly ItemsRepository _upgradeItemsRepository;
        private readonly InventoryModel _inventoryModel;
        private readonly InventoryController _inventoryController;

        public ShedController(
            [NotNull] InventoryModel inventoryModel,
            [NotNull] TransportModel transport, 
            [NotNull] List<UpgradeItemConfig> upgradeItemConfigs)
        {
            if (upgradeItemConfigs == null)
                throw new ArgumentNullException(nameof(upgradeItemConfigs));
            
            _transport = transport ?? throw new ArgumentNullException(nameof(transport));
            _inventoryModel = inventoryModel ?? throw new ArgumentNullException();
            
            _upgradeHandlersRepository = new UpgradeHandlersRepository(upgradeItemConfigs);
            AddRepository(_upgradeHandlersRepository);

            _upgradeItemsRepository =
                new ItemsRepository(upgradeItemConfigs.Select(value => value.ItemConfig).ToList());
            AddRepository(_upgradeItemsRepository);
            
            _inventoryController = new InventoryController(_inventoryModel, _upgradeItemsRepository);
            AddController(_inventoryController);
        }

        public void Enter()
        {
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
    }
}