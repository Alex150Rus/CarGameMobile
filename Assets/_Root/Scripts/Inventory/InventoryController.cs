using System;
using Inventory.Items;
using JetBrains.Annotations;

namespace Inventory
{
    internal interface IInventoryController
    {
        void ShowInventory(Action callback);
        void HideInventory();
    }
    
    
    internal class InventoryController: BaseController, IInventoryController
    {
        private readonly IInventoryModel _inventoryModel;
        private readonly IItemsRepository _itemsRepository;
        private readonly IInventoryView _inventoryView;

        public InventoryController(
            [NotNull] IInventoryModel inventoryModel,
            [NotNull] IItemsRepository itemsRepository,
            [NotNull] IInventoryView inventoryView
        )
        {
            _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
            _itemsRepository = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));
            _inventoryView = inventoryView ?? throw new ArgumentNullException(nameof(inventoryView));
        }
        
        public void ShowInventory(Action callback)
        {
            
        }

        public void HideInventory()
        {
            
        }
    }
}